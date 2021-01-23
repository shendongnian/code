    public class CustomDependencyResolver : IDependencyResolver
    {
        public CustomDependencyResolver(IContainer container)
        {
           // ...
        }
        public object GetService(Type serviceType)
        {
            // pass resolution off to your container
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            // pass resolution off to your container
        }
    }
