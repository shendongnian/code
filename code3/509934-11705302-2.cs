    public class Product
    {
        public int Id { get; set; }
    }
    public class ProductsDAL
    {
        public static IEnumerable<Product> GetProducts()
        {
            return new List<Product>(new Product[]
                { 
                    new Product() { Id = 1 },
                    new Product() { Id = 2 }
                });
        }
    }
