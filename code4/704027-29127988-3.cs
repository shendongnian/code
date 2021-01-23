    public class ProductsController : ODataController
    {
        [EnableQuery]
        public IHttpActionResult Get()
        {
            var products = context.Products; // IQueryable<Product>
            return Ok(products.Project().To<ProductDTO>());
        }
    }
