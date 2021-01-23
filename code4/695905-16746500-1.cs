    x.For<DbContext>()
     .Use<Data.Entity.TokoContainer>()
     // example, taking the first conn string - adjust as needed
     .Ctor<string>().Is(ConfigurationManager.ConnectionStrings[0].ConnectionString);
    ;
