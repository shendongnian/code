    var connStr = appSettings.Get("SQLSERVER_CONNECTION_STRING", //AppHarbor or Local connection string
        ConfigUtils.GetConnectionString("UserAuth"));
    container.Register<IDbConnectionFactory>(
        new OrmLiteConnectionFactory(connStr, //ConnectionString in Web.Config
            SqlServerOrmLiteDialectProvider.Instance) {
                ConnectionFilter = x => new ProfiledDbConnection(x, Profiler.Current)
            });
