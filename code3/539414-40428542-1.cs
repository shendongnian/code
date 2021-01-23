    DbConfiguration.Loaded += (_, a) => 
       { 
           a.ReplaceService<DbProviderServices>((s, k) => new MyProviderServices(s)); 
           a.ReplaceService<IDbConnectionFactory>((s, k) => new MyConnectionFactory(s)); 
       };
