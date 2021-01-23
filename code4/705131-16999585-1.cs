    public static class UnityBootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            var resolver = DependencyResolver.Current;
            var newResolver = new Infrastructure.IoC.UnityDependencyResolver(container, resolver);
            DependencyResolver.SetResolver(newResolver);
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            var unityConfigSection = WebConfigurationManager.GetSection("unity") as UnityConfigurationSection;
            if (unityConfigSection != null)
            {
                unityConfigSection.Configure(container);
            }
            return container;
        }
    }
