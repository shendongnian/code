    container.AddFacility<TypedFactoryFacility>();
    container.Register(
        Component.For<IDeveloperFactory>().AsFactory(),
        Component.For<IDeveloper>().ImplementedBy<Developer>().LifestyleScoped(),
        Component.For<ITask>().ImplementedBy<WriteCodeTask>().LifestyleTransient(),
        Component.For<Lazy<IDeveloper>>().LifestyleTransient() // i don't use 4.0 so this is my own implementation of Lazy<> which depends on a Func<> on ctor
    );
