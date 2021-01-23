    public static class StructuremapMvc
    {
        public static void Start()
        {
            // Create new Structuremap Controller factory so Structure map can resolve the parameter dependencies.
            ControllerBuilder.Current.SetControllerFactory(new StructuremapControllerFactory());
            IContainer container = IoC.Initialize();
            DependencyResolver.SetResolver(new StructureMapDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new StructureMapDependencyResolver(container);
        }
    }
