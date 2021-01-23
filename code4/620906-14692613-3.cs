    // Define a lifestyle once based on the deployment.
    Container.Options.DefaultScopedLifestyle =
        Lifestyle.CreateHybrid(
            lifestyleSelector: HostingEnvironment.ApplicationHost != null,
            trueLifestyle: new WebRequestLifestyle(),
            falseLifestyle: new LifetimeScopeLifestyle());
    // And use it for registering the unit of work
    // (no extra interfaces needed anymore).
    container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
    // After setting DefaultScopedLifestyle, you can usr Lifestyle.Scoped
    container.RegisterCollection(
        typeof(ISubscriber<>),
        new [] { typeof(ISubscriber<>).Assembly },
        Lifestyle.Scoped);
