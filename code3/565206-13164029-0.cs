    private static void WireUp()
    {
        container = new UnityContainer();
        container.RegisterInstance(SomeProvider.Provider);
        container.RegisterInstance(new SomeDependency());
        container.RegisterType<SomeBusinessLayer>(new ContainerControlledLifetimeManager());
        container.BuildUp(SomeProvider.Provider);
    }
