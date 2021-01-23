    container.RegisterSingle<IDatabaseFactory, SqlDatabaseFactory>();
    container.RegisterInitializer<SqlDatabaseFactory>(factory =>
    {
        factory.ConnectionString = connectionString; 
    });
