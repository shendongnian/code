    builder.Register<MySingleton>().AsSelf().AsImplementedInterfaces();
    //.. other registrations
    var container = builder.Build();
    // now resolve each singleton, forcing all to be constructed if not already
    //   and then register the instance
    var builder2 = new ContainerBuilder();
    var mySingleton = container.Resolve<MySingleton>();
    builder2.Register(c => mySingleton).AsSelf().AsImplementedInterfaces();
    builder2.Update(container);
    //.....
    var scope = container.BeginLifetimeScope("child scope");   
    scope.Resolve<MySingleton>(); //not resolved from root!
