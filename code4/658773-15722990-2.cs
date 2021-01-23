    public class AppBootstrapper : Bootstrapper<ShellViewModel>
    {
        // The Castle Windsor container
        private IWindsorContainer _container;
        protected override void Configure()
        {
            base.Configure();
            // Create the container, install from the current assembly (installer code shown in next section below)
            _container = new WindsorContainer();
            _container.Install(FromAssembly.This());
        }
        // Matches up with Windsors ResolveAll nicely
        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return (IEnumerable<object>)_container.ResolveAll(service);
        }
        // Matches up with Windsors Resolve
        protected override object GetInstance(Type service, string key)
        {
            return string.IsNullOrEmpty(key) ? _container.Resolve(service) : _container.Resolve(key, service);
        }
        // Windsor doesn't do property injection by default, but it's easy enough to get working:
        protected override void BuildUp(object instance)
        {
            // Get all writable public properties on the instance we will inject into
            instance.GetType().GetProperties().Where(property => property.CanWrite && property.PropertyType.IsPublic)
            // Make sure we have a matching service type to inject by looking at what's registered in the container
                                              .Where(property => _container.Kernel.HasComponent(property.PropertyType))
            // ...and for each one inject the instance
                                              .ForEach(property => property.SetValue(instance, _container.Resolve(property.PropertyType), null));
        }
    }
