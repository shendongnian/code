    EntityConnectionStringBuilder entityBuilder =
        new EntityConnectionStringBuilder();
        //Set the provider name.
        entityBuilder.Provider = providerName;
        
        // Set the provider-specific connection string.
        entityBuilder.ProviderConnectionString = providerString;
        
        // Set the Metadata location.
        entityBuilder.Metadata = @"res://*/AdventureWorksModel.csdl|
                                    res://*/AdventureWorksModel.ssdl|
                                    res://*/AdventureWorksModel.msl";
    using (EntityConnection conn =
        new EntityConnection(entityBuilder.ToString()))
    {
        conn.Open();
        Console.WriteLine("Just testing the connection.");
        conn.Close();
    }
