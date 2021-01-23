        public class ProductController : Controller
        {
            private IProductRepository Repository { get; private set; }
            // TODO Will be used by the DiC.
            public ProductController(IProductRepository repository)
            {
                this.Repository = repository;
            }
        }
