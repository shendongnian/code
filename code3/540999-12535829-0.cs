    private static DbConnection CreateConnectionWrapper(string nameOrConnectionString) {
        var providerInvariantName = "System.Data.SqlClient";
        var connectionString = nameOrConnectionString;
        //name=connectionName format
        var index = nameOrConnectionString.IndexOf('=');
        if (nameOrConnectionString.Substring(0, index).Trim()
            .Equals("name", StringComparison.OrdinalIgnoreCase))
        {
            nameOrConnectionString = nameOrConnectionString
                .Substring(index + 1).Trim();
        }
        //look up connection string name
        var connectionStringSetting =
            ConfigurationManager.ConnectionStrings[nameOrConnectionString];
        if (connectionStringSetting != null)
        {
            providerInvariantName = connectionStringSetting.ProviderName;
            connectionString = connectionStringSetting.ConnectionString;
        }
        //create the special connection string with the provider name in it
        var wrappedConnectionString = "wrappedProvider=" + 
            providerInvariantName + ";" + 
            connectionString;
        //create the tracing wrapper
        var connection = new EFTracingConnection
                                {
                                    ConnectionString = wrappedConnectionString
                                };
        //hook up logging here
        connection.CommandFinished +=
            (sender, args) => Console.WriteLine(args.ToTraceString());
        return connection; }
    
