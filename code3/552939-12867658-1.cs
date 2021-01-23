    container.AddFacility<FactorySupportFacility>();
    container.Register(Component.For<IService>()
        .UsingFactoryMethod(() =>
        {
            var log = container.Resolve<ILogger>();
            return new RealService(log);
        })
        .LifeStyle.Transient);
