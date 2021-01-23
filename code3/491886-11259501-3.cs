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
        //'GetAllInstance' typo corrected to GetAllInstances. 6 chars edit limit (did they not know code has to be exact on this limit???) necessitated this note
        public void Dispose()
        {
        }
    }
