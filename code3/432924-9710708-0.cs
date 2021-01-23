    public interface IProductRepository
    {
        Product Get(int id);
        ...
    }
    public class SqlProductRepository : IProductRepository
    {
        public Product Get(int id) { ... }
        ...
    }
    public class MockProductRepository : IProductRepository
    {
        private IDictionary<int, Product> _products = new Dictionary<int, Product>()
        {
            { 1, new Product() { Name = "MyItem" } }
        };
        public Product Get(int id) { return _products[id]; }
        ...
    }
    public class AwesomeBusinessLogic
    {
        private IProductRepository _repository;
        public AwesomeBusinessLogic(IProductRepository repository)
        {
            _repository = repository;
        }
        public Product GetOneProduct()
        {
            return _repository.GetProduct(1);
        }
    }
