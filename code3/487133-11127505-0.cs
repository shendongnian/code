    string connectionString = new System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"]);
     
    System.Data.SqlClient.SqlConnectionStringBuilder scsb = new System.Data.SqlClient.SqlConnectionStringBuilder(connectionString);
     
    EntityConnectionStringBuilder ecb = new EntityConnectionStringBuilder();
    ecb.Metadata = "res://*/Sample.csdl|res://*/Sample.ssdl|res://*/Sample.msl";
    ecb.Provider = "System.Data.SqlClient";
    ecb.ProviderConnectionString = scsb.ConnectionString;
     
    dataContext = new SampleEntities(ecb.ConnectionString);
