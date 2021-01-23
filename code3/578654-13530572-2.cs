     internal class MvcWindsorDependencyResolver : IDependencyResolver
        {
            private readonly IWindsorContainer container;
    
            public MvcWindsorDependencyResolver(IWindsorContainer container)
            {
                this.container = container;
            }
    
            public object GetService(Type serviceType)
            {
                return container.Kernel.HasComponent(serviceType) ? container.Resolve(serviceType) : null;
            }
    
            public IEnumerable<object> GetServices(Type serviceType)
            {
                return container.Kernel.HasComponent(serviceType) ? container.ResolveAll(serviceType).Cast<object>() : new object[] { };
            }
        }
