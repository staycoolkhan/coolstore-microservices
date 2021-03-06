using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using N8T.Infrastructure.App.Dtos;
using ShoppingCartService.Application.Checkout;
using ShoppingCartService.Application.CreateShoppingCartWithProduct;
using ShoppingCartService.Application.GetCartByUserId;
using ShoppingCartService.Application.UpdateAmountOfProductInShoppingCart;

namespace ShoppingCartService.Api.Http.Controllers
{
    [ApiController]
    [Route("api/carts")]
    public class CartController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public async Task<CartDto> Get([FromServices] IMediator mediator) =>
            await mediator.Send(new GetCartByUserIdQuery());

        [Authorize]
        [HttpPost]
        public async Task<CartDto> Post(CreateShoppingCartWithProductQuery query, [FromServices] IMediator mediator) =>
            await mediator.Send(query);

        [Authorize]
        [HttpPut]
        public async Task<CartDto> Put(UpdateAmountOfProductInShoppingCartQuery query,
            [FromServices] IMediator mediator) =>
            await mediator.Send(query);

        [Authorize]
        [HttpPut("checkout")]
        public async Task<CartDto> CheckOut([FromServices] IMediator mediator) =>
            await mediator.Send(new CheckOutQuery());
    }
}
