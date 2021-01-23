            FluentConfiguration fc = Fluently.Configure()
                .Database(MySQLConfiguration.Standard.ConnectionString(connectionString).ShowSql()
                .Dialect<NHibernate.Dialect.MySQL5Dialect>().Driver<NHibernate.Driver.MySqlDataDriver>())
                .Mappings(m => m.FluentMappings
                    .AddFromAssemblyOf<UsuarioMap>()
                    .Conventions.Add(PrimaryKey.Name.Is(a => string.Concat("Id", a.EntityType.Name)))
                    .Conventions.Add(ForeignKey.Format((x, y) => string.Concat("Id", y.Name))))
                .ExposeConfiguration(conf => conf.AddAuxiliaryDatabaseObject(new BorradoUsuarioTrigger()))
                .ExposeConfiguration(BuildSchema);
