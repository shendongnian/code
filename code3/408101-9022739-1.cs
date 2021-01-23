    kernel.Bind(
        x => x.FromThisAssembly()
              .SelectAllClasses()
              .InNamespace("Services")
              .BindToAllInterfaces()
              .Configure(b => b.InSingletonScope()));
    kernel.Bind(
        x => x.FromThisAssembly()
              .SelectAllClasses()
              .InNamespace("Repositories")
              .BindToAllInterfaces());
