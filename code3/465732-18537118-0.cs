        public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HubConfiguration()
            {
                Resolver = new SignalRSimpleInjectorDependencyResolver(Container)
            };
            app.MapSignalR(config);
        }
    }
    public class SignalRSimpleInjectorDependencyResolver : DefaultDependencyResolver, IDependencyResolver
    {
        private Container _container;
        public SignalRSimpleInjectoryDependencyResolver(Container container)
        {
            _container = container;
        }
        public override object GetService(Type serviceType)
        {
            if (_container.GetRegistration(serviceType, false) != null)
            {
                return _container.GetInstance(serviceType);
            }
            else
            {
                return base.GetService(serviceType);
            }
        }
        public override IEnumerable<object> GetServices(Type serviceType)
        {
            if (_container.GetRegistration(serviceType, false) != null)
            {
                return _container.GetAllInstances(serviceType);
            }
            else
            {
                return base.GetServices(serviceType);
            }
        }
    }
