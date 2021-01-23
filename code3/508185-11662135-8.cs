    // Explicitly 
    var builder = new ContainerBuilder();
    builder.Register<UnitOfWork>(b => new UnitOfWork());
    builder.Register<Repository>(b => new Repository(b.Resolve<UnitOfWork>()));
    builder.Register(b => new Service(b.Resolve<Repository>(), b.Resolve<UnitOfWork>()));
