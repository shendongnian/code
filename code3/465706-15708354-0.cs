    The following worked for me. In addition, you will need to register a delegate with the container for your hub class before instantiating the dependency resolver.
    ex: container.Register<MyHub>(() =>
            {
                IMyInterface dependency = container.GetInstance<IMyInterface>();
                return new MyHub(dependency);
            });
    public class SignalRDependencyResolver : DefaultDependencyResolver
    {
        private Container _container;
        private HashSet<Type> _types = new HashSet<Type>();
        public SignalRDependencyResolver(Container container)
        {
            _container = container;
            RegisterContainerTypes(_container);
        }
        private void RegisterContainerTypes(Container container)
        {
            InstanceProducer[] producers = container.GetCurrentRegistrations();
            foreach (InstanceProducer producer in producers)
            {
                if (producer.ServiceType.IsAbstract || producer.ServiceType.IsInterface)
                    continue;
                if (!_types.Contains(producer.ServiceType))
                {
                    _types.Add(producer.ServiceType);
                }
            }
        }
        public override object GetService(Type serviceType)
        {
            return _types.Contains(serviceType) ? _container.GetInstance(serviceType) : base.GetService(serviceType);
        }
        public override IEnumerable<object> GetServices(Type serviceType)
        {
            return _types.Contains(serviceType) ? _container.GetAllInstances(serviceType) : base.GetServices(serviceType);
        }
    }
