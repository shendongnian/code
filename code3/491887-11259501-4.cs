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
            return this.container.GetAllInstances(serviceType);
        }
        public void Dispose()
        {
        }
    }
