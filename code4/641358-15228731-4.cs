    var builder = new ContainerBuilder();
    builder
        .RegisterGeneric(typeof(Repository<>)).AsSelf();
    builder
        .RegisterGeneric(typeof(UnitOfWork<>))
        .As(typeof(IUnitOfWork<>))
        .InstancePerDependency();
    var container = builder.Build();
    
    // sample usage
    var u = container.Resolve<IUnitOfWork<MyEntity>>();
