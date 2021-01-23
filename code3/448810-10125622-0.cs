    kernel.Bind(x => x
          .FromAssemblyContaining<CategoryRepository>()
          .SelectAllClasses().EndingWith("Repository")
          .BindAllInterfaces()
          .Configure(b => b.InRequestScope());
    kernel.Bind(x => x
          .From("EFMVC.Domain")
          .SelectAllClasses().InheritedFromAny(typeof(ICommandHandler<>))
          .BindAllInterfaces()
          .Configure(b => b.InRequestScope());
