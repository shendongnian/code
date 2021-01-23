    public class Product
    {
        public decimal Price { get; set; }
    }
    public class SimpleProduct : Product { }
    public class ServiceProduct : Product
    {
        public string Service { get; set; }
    }
    
    public class ProductBuilder<T> where T : Product, new()
    {
        private List<Action<T>> actions = new List<Action<T>>();
    
        public T Build()
        {
            T product = new T();
            foreach (var action in actions)
            {
                action(product);
            }
    
            return product;
        }
        public void Configure(Action<T> action)
        {
            actions.Add(action);
        }
    }
    
    public static class ProductExtensions
    {
        public static ProductBuilder<T> WithPrice<T>(this ProductBuilder<T> builder, decimal price)
            where T : Product
        {
            builder.Configure(product => product.Price = price);
            return builder;
        }
    
        public static ProductBuilder<T> WithService<T>(this ProductBuilder<T> builder, string service)
                where T : ServiceProduct
        {
            builder.Configure(product => product.Service = service);
            return builder;
        }
    }
