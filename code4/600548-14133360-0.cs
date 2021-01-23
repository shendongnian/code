    DbProviderFactory providerFactory = DbProviderFactories.GetFactory("The Provider Name");
    
    using (DbConnection connection = providerFactory.CreateConnection())
    {
        connection.ConnectionString = "The Connection String";
    
        connection.Open();
    
        // Use the "connection" object here
    }
