    var originalConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CSName"].ConnectionString;
    var ecsBuilder = new EntityConnectionStringBuilder(originalConnectionString);
    var sqlCsBuilder = new SqlConnectionStringBuilder(ecsBuilder.ProviderConnectionString)
    {
        DataSource = "newDBHost"
    };
    var providerConnectionString = sqlCsBuilder.ToString();
    ecsBuilder.ProviderConnectionString = providerConnectionString;
    string contextConnectionString = ecsBuilder.ToString();
    using (var db = new SMSContext(contextConnectionString))
    {
        ...
    }
