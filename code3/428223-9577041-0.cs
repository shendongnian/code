    private static ISessionFactory CreateSessionFactory()
    {
      return Fluently.Configure()
        .Database(
          SQLiteConfiguration.Standard
            .UsingFile("firstProject.db")
        )
        .Mappings(m =>
          m.FluentMappings.AddFromAssemblyOf<Program>())
        .BuildSessionFactory();
    }
