    _container.AddFacility<TypedFactoryFacility>();
    _container.Register(
        Component.For<Group>(),
        Component.For<IGroupViewModelFactory>()
        .AsFactory());
