    public interface IProductFactory
    {
        T Create<T>() where T : ProductBase, new();
        void Destroy(ProductBase obj)
    }
    public class ProductFactory : IProductFactory
    {
        private readonly WindsorContainer _container;
        public ProductFactory(WindsorContainer container)
        {
             _container = container;
        }
        public T Create<T>() where T : ProductBase, new()
        {
            return _container.Resolve<T>();
        }
        public void Destroy(ProductBase obj)
        {
            _container.Release(obj);
        }
    }
