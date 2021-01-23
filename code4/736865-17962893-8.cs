        var fcfg = Fluently.Configure()
            .Database(SQLiteConfiguration.Standard.ConnectionString(connString))
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<TMap1>())
            .Cache(c => c.UseQueryCache());
        
        if (typeof(TMap1) != typeof(TMap2))
            fcfg.Mappings(m => m.FluentMappings.AddFromAssemblyOf<TMap2>()));
        
        cfg = fcfg.BuildConfiguration();
        sessionFactory = cfg.BuildSessionFactory();
