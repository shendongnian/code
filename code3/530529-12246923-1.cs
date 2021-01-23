    public class ProductRepository : IProductRepority
    {
        private readonly string connString;
        public ProductRepository(string conn)
        {
            connString = conn;
        }
    }
