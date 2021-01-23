    Bind<ConnectionStringProvider>().ToConstant(
        new ConnectionStringProvider
        {
            Db1ConnectionString = db1ConnectionString,
            Db2ConnectionString = db2ConnectionString,
        });
    Bind<IFoo>().To<SqlFoo>();
    Bind<IBar>().To<SqlBar>();
