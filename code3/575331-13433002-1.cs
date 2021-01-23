    Bind<ISessionFactory>().ToMethod(x =>
        {
            return Fluently.Configure()
                .Database(SQLiteConfiguration.Standard
                    .UsingFile(CreateOrGetDataFile(Kernel.Get("somefile.db"))).AdoNetBatchSize(128))
                .Mappings( 
                    m => m.FluentMappings.AddFromAssembly(Assembly.Load("Sauron.Core"))
                          .Conventions.Add(PrimaryKey.Name.Is(p => "Id"), ForeignKey.EndsWith("Id")))
                .BuildSessionFactory();
        }).InSingletonScope();
