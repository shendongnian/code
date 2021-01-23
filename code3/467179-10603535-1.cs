    container.AddFacility<FactorySupportFacility>();
    container.Register(Component.For<IFoo>()
        .UsingFactoryMethod(() =>
        {
            return condition
                ? container.Resolve<FooA>()
                : container.Resolve<FooB>();
        })
        .LifeStyle.Transient);
