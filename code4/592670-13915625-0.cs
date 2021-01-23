    var kernel = new StandardKernel();
    kernel.Bind<IDbConnection>()
          .To<SqlConnection>()
          .WithConstructorArgument("connectionString", connectionString);
    kernel.Bind<IDbTransaction>()
          .ToMethod(x => x.Kernel.Get<IDbConnection>().BeginTransaction());
