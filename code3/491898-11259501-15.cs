    public class SimpleInjectorHttpDependencyResolver : 
        System.Web.Http.Dependencies.IDependencyResolver
    {
        private readonly Container container;
        public SimpleInjectorHttpDependencyResolver(
            Container container)
        {
            this.container = container;
        }
        
        public System.Web.Http.Dependencies.IDependencyScope
            BeginScope()
        {
            return this;
        }
        public object GetService(Type serviceType)
        {
            IServiceProvider provider = this.container;
            return provider.GetService(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            IServiceProvider provider = this.container;
            Type collectionType = typeof(IEnumerable<>).MakeGenericType(serviceType);
            var services =(IEnumerable<object>)this.ServiceProvider.GetService(collectionType);
            return services ?? Enumerable.Empty<object>();
        }
        public void Dispose()
        {
        }
    }
