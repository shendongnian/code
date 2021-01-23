    var builder = new ContainerBuilder();
    builder.RegisterType<FirstType>().As<IDependency>();
    builder.RegisterType<SecondType>().As<IDependency>();
    builder.RegisterType<ThirdType>().As<IDependency>();
    var container = builder.Build();
    using(var scope = container.BeginLifetimeScope())
    {
      var allDependencies = scope.Resolve<IEnumerable<IDependency>>();
      // allDependencies will contain all three of the registered types.
    }
