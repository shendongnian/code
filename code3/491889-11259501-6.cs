    using SimpleInjector.Extensions.LifetimeScoping;
    public class LifetimeScopedSimpleInjectorDependencyResolver
        : System.Web.Http.Dependencies.IDependencyResolver
    {
        private readonly Container container;
        private readonly LifetimeScope lifetimeScope;
        public SimpleInjectorDependencyResolver(
            Container container)
            : this(container, false)
        {
        }
        private SimpleInjectorDependencyResolver(
            Container container, bool createScope)
        {
            this.container = container;
            
            if (createScope)
            {
                this.lifetimeScope = container.BeginLifetimeScope();
            }
        }
        public IDependencyScope BeginScope()
        {
            return new SimpleInjectorDependencyResolver(this.container, true);
        }
        public object GetService(Type serviceType)
        {
            return ((IServiceProvider)this.container).GetService(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.container.GetAllInstances(serviceType);
        }
        
        public void Dispose()
        {
           if (this.lifetimeScope != null)
           {
               this.lifetimeScope.Dispose();
           }
        }
    }
