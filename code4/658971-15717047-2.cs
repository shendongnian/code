    public class Container
    {
        private readonly Dictionary<Type, Func<object>> registrations =
            new Dictionary<Type, Func<object>>();
        
        public void Register<TService, TImplementation>()
            where TImplementation : TService
        {
            this.registrations.Add(typeof(TService), 
                () => this.GetInstance<TImplementation>());
        }
        public void Register<TService>(Func<TService> instanceCreator)
        {
            this.registrations.Add(typeof(TService), () => instanceCreator());
        }
        public void RegisterSingle<TService>(TService instance)
        {
            this.registrations.Add(typeof(TService), () => instance);
        }
        
        public void RegisterSingle<TService>(Func<TService> instanceCreator)
        {
            var lazy = new Lazy<TService>(instanceCreator, 
                LazyThreadSafetyMode.ExecutionAndPublication);
            this.Register<TService>(() => lazy.Value);
        }    
        public TService GetInstance<TService>()
        {
            return (TService)this.GetInstance(typeof(TService));
        }
        public object GetInstance(Type serviceType)
        {
            Func<object> creator;
            if (!this.registrations.TryGetValue(serviceType, out creator))
            {
                if (!serviceType.IsAbstract)
                {
                    return this.CreateConcreteType(serviceType);
                }
            }
            return this.registrations[serviceType]();
        }
        private object CreateConcreteType(Type implementationType)
        {
            var ctor = implementationType.GetConstructors().Single();
            var parameters = (
                from parameter in ctor.GetParameters()
                select this.GetInstance(parameter.ParameterType))
                .ToArray();
            return Activator.CreateInstance(implementationType, parameters);
        }
    }
