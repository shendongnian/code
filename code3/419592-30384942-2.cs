    // Register "Data" as itself, with the given scope.
    builder.RegisterType<Data>().AsSelf().InstancePerLifetimeScope();
    // The dependency injected into 'Data' instances.
    builder.RegisterType<SpecificDataDependency>().As<IDependencyOfData>();
    // And getting to the point:
    // Register a factory method that uses the container context.
    builder.Register<IMyService>(ctx => new MyService(ctx.Resolve<Data>()));
    
