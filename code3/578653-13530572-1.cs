     internal class WebApiWindsorDependencyResolver : IDependencyResolver
        {
            private readonly IWindsorContainer container;
    
            public WebApiWindsorDependencyResolver(IWindsorContainer container)
            {
                if (container == null) { throw new ArgumentNullException("container"); }
                this.container = container;
            }
    
            public object GetService(Type t)
            {
                return this.container.Kernel.HasComponent(t) ? this.container.Resolve(t) : null;
            }
    
            public IEnumerable<object> GetServices(Type t)
            {
                return this.container.ResolveAll(t).Cast<object>().ToArray();
            }
    
            public IDependencyScope BeginScope()
            {
                return new ReleasingDependencyScope(this as IDependencyScope, this.container.Release);
            }
    
            public void Dispose()
            {
            }
        }
