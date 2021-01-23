    private static FluentConfiguration GetConfiguration()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2005.ConnectionString(
                        c => c.FromConnectionStringWithKey("CustomConnectionString"))
                        .Dialect<DerivedDialectWithNewId>()));
        }
