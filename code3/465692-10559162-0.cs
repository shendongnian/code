    public class SimpleInjectorResolver : DefaultDependencyResolver
    {
        private Container _container;
        public SimpleInjectorResolver(Container container)
        {
            _container = container;
        }
        [DebuggerStepThrough]
        public override object GetService(Type serviceType)
        {
            IServiceProvider provider = _container;
            return provider.GetService(serviceType);
        }
        [DebuggerStepThrough]
        public override IEnumerable<object> GetServices(
            Type serviceType)
        {
            return _container.GetAllInstances(serviceType);
        }
    }
