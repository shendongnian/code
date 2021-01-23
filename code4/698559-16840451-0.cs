    var builder = new ContainerBuilder();
    builder.RegisterType<AppLevelSingleton>().SingleInstance();
    var container = builder.Build();
    // Create a nested lifetime scope for your background threads
    // that registers things as InstancePerDependency, etc. Pass
    // that scope to whatever handles dependency resolution on the thread.
    var backgroundScope = container.BeginLifetimeScope(
      b => b.RegisterType<DatabaseFactory>()
            .As<IDatabaseFactory>()
            .InstancePerDependency());
    // Create a nested lifetime scope for the web app that registers
    // things as InstancePerHttpRequest, etc. Pass that scope
    // as the basis for the MVC dependency resolver.
    var webScope = container.BeginLifetimeScope(
      b => b.RegisterType<DatabaseFactory>()
            .As<IDatabaseFactory>()
            .InstancePerHttpRequest());
    var resolver = new AutofacDependencyResolver(webScope);
    DependencyResolver.SetResolver(resolver);
