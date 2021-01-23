    public class ProductFactory
    {
        public T Create<T>() where T : ProductBase, new()
        {
            return new T();
        }
    }
