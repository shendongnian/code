    kernel.Bind<ISessionFactory>().ToMethod(x =>
    {
        var parameter = x.Parameters.SingleOrDefault(p => p.Name == "dbName");
        var dbName = "someDefault.db";
        if (parameter != null)
        {
            dbName = (string) parameter.GetValue(x, x.Request.Target);
        }
        return Fluently.Configure()
            .Database(SQLiteConfiguration.Standard
                .UsingFile(CreateOrGetDataFile(dbName)))
                //...
            .BuildSessionFactory();
    }).InSingletonScope();
