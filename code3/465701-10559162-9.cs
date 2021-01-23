    public class SimpleInjectorResolver : DefaultDependencyResolver
    {
        private Container _container;
        public SimpleInjectorResolver(Container container)
        {
            _container = container;
        }
        public override object GetService(Type type)
        {
            return ((IServiceProvider)_container).GetService(type) ??
                base.GetService(type) ;
        }
        public override IEnumerable<object> GetServices(Type type)
        {
            return _container.GetAllInstances(type);
        }
    }
