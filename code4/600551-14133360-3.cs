    DbProviderFactory providerFactory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["TheConnectionString"].ProviderName);
    
    using (DbConnection connection = providerFactory.CreateConnection())
    {
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["TheConnectionString"].ConnectionString;
    
        connection.Open();
    
        // Use the "connection" object here
    }
