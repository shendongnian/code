    public class ProductsController : ApiController 
    {
        public IEnumerable<Product> GetAllProducts() {
            return products;
        }
        public Product GetProductById(int id) {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return product;
        }
        public Product GetProductByName(string categoryName) {
            var product = products.FirstOrDefault((p) => p.Name == categoryName);
            if (product == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return product;
        }
        public IEnumerable<Product> GetProductsByCategory(string category) {
            return products.Where(p => string.Equals(p.Category, category,
                    StringComparison.OrdinalIgnoreCase));
        }
        public IEnumerable<Product> GetProductsByPriceGreaterThan(decimal price) {
            return products.Where((p) => p.Price > price);
        }
    }
