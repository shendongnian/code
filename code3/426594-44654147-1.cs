    public static class UnityConfig
    {
        public static void ConfigureUnity(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<ISomethingRepository, SomethingRepository>();
            config.DependencyResolver = new UnityResolver(container);
        }
    }
