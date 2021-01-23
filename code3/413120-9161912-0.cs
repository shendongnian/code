    public class ProductService
    {
        public IEnumerable<Product> GetAllProducts()
        {
            using(MyContext context = new MyContext())
            {
                return context.Products.ToArray();
            }
        }
    }
