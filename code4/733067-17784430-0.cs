    public interface IProductsRepository
    {
        IEnumerable<Product> FindAll();
        IEnumerable<Product> FindBySupplierId(int supplierId);
    }
    public class ProductsRepository : IProductsRepository
    {
        private object _propertyName;
        private DbContext _db;
        public ProductsRepository(DbContext db)
        {
            _db = db;
        }
        public IEnumerable<Product> FindAll()
        {
            return _db.Set<Product>();
        }
        public IEnumerable<Product> FindBySupplierId(int supplierId)
        {
            return _db.Set<Product>()
                      .Where(p => p.SupplierID == supplierId);
        }
    }
