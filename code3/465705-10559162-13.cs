    public sealed class SimpleInjectorResolver 
        : Microsoft.AspNet.SignalR.IDependencyResolver
    {
        private Container container;
        private IServiceProvider provider;
        private DefaultDependencyResolver defaultResolver;
        public SimpleInjectorResolver(Container container)
        {
            this.container = container;
            this.provider = container;
            this.defaultResolver = new DefaultDependencyResolver();
        }
        [DebuggerStepThrough]
        public object GetService(Type serviceType)
        {
            // Force the creation of hub implementation to go
            // through Simple Injector without failing silently.
            if (!serviceType.IsAbstract && typeof(IHub).IsAssignableFrom(serviceType))
            {
                return this.container.GetInstance(serviceType);
            }
            return this.provider.GetService(serviceType) ?? 
                this.defaultResolver.GetService(serviceType);
        }
        [DebuggerStepThrough]
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.container.GetAllInstances(serviceType);
        }
        public void Register(Type serviceType, IEnumerable<Func<object>> activators)
        {
            throw new NotSupportedException();
        }
        public void Register(Type serviceType, Func<object> activator)
        {
            throw new NotSupportedException();
        }
        public void Dispose()
        {
            this.defaultResolver.Dispose();
        }
    }
