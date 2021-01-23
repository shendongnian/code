    public class FunqDependencyResolver : IDependencyResolver
    {
        private readonly ContainerResolveCache cache;
        public FunqDependencyResolver(Container container)
        {
            this.cache = new ContainerResolveCache(container);
            var controllerTypes =
                (from type in Assembly.GetCallingAssembly().GetTypes()
                 where typeof(IController).IsAssignableFrom(type)
                 select type).ToList();
            container.RegisterAutoWiredTypes(controllerTypes);
        }
        public object GetService(Type serviceType)
        {
            return this.cache.CreateInstance(serviceType, true);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Enumerable.Empty<object>();
        }
    }
