    public class ProductRepository : Repository<Product> {
        public ProductRepository(DbContext dbContext)
            : base(dbContext) {
        }
        public IEnumerable<Product> GetProductList(string Type) {
            IEnumerable<Product> fLit = from p in Entities select p;
            return fLit;
        }
    }
