    public class ProductService
    {
        public IEnumerable<Product> GetAllProducts()
        {
            using(MyContext context = new MyContext())
            {
                foreach(var product in context.Products)
                    yield return product;
            }
        }
    }
