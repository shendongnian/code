     var provider = (DbProviderFactory)System.Data.Entity.DbConfiguration
                .DependencyResolver
                .GetService(typeof(DbProviderFactory), "invariant provider name");
            var conn = provider.CreateConnection();
            //conn.ConnectionString = "sample connection string";
            DbInterception.Dispatch.Connection.SetConnectionString(conn, new DbConnectionPropertyInterceptionContext<string>()
                .WithValue("sample connection string"));
    return new SampleDbContext(conn,true);
