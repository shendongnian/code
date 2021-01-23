    [RoutePrefix("api")]
    public class ShopifyWebHookController : ApiController
    {
        [VerifyShopify]
        [HttpPost]
        public IHttpActionResult HandleWebhook(...)
        {
            ...
        }
    }
