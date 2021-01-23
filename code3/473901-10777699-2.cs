    public class SomeDataAccessClass
    {
        public static IQueryable<Product> GetAllProducts()
        {
            var products = from o in ContextPerRequest.Current.Products
                           select o;
            return products;
        }
    }
