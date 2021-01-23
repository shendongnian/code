    public static void Register(IUnityContainer container)
    {
        container
            .RegisterType<IEmail, Email>(
            new ContainerControlledLifetimeManager(),
            new InjectionFactory(c => new Email(
                "To Name", 
                "to@email.com")));
    }
