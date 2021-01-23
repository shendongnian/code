    public class SimpleInjectorResolver : DefaultDependencyResolver
    {
        private Container _container;
        public SimpleInjectorResolver(Container container)
        {
            _container = container;
        }
        public override object GetService(Type type)
        {
            return base.GetService(type) ??
                ((IServiceProvider)_container).GetService(type);
        }
        public override IEnumerable<object> GetServices(Type type)
        {
            return base.GetServices(type) ??
                _container.GetAllInstances(type);
        }
    }
