      builder.RegisterType<DbRepository>()
             .Keyed<IRepository>(RepositoryKind.CacheNeeded);
      builder.Register(c => new CacheRepository(c.ResolveKeyed<IRepository(RepositoryKind.CacheNeeded)))
             .Keyed<IRepository>(RepositoryKind.DataNeeded);
      builder.Register(c => new HomeController(c.ResolveKeyed<IRepository>(RepositoryKind.DataNeeded)));
