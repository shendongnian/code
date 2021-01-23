        public class ProductsController : ApiController
        {
            public Product Get(int id)
            {
                return new Product
                {
                    Id = id,
                    Name = "prd " + id
                };
            }
        }
