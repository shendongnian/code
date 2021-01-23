    public static class SimpleInjectorInitializer
    {
        public static void Initialize()
        {
            // Create the IOC container.
            var container = new Container();
            InitializeContainer(container);
            container.RegisterMvcAttributeFilterProvider();
            
            // Verify the container configuration
            container.Verify();
            // Register the dependency resolver.
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
        private static void InitializeContainer(Container container)
        {
            GlobalConfiguration.Configuration.Services
                .Replace(typeof(IAssembliesResolver),
                    new CustomAssembliesResolver());
        
            var services = GlobalConfiguration.Configuration.Services;
            var controllerTypes = services.GetHttpControllerTypeResolver()
                .GetControllerTypes(services.GetAssembliesResolver());
            
            // register Web API controllers (important!)
            foreach (var controllerType in controllerTypes)
            {
                container.Register(controllerType);
            }        
        }
    }
