    class ConnectionStringFactory
    {
        internal stati string BuildModelConnectionString(string connectionString)
        {
            var builder = new EntityConnectionStringBuilder
            {
                Provider = "System.Data.SqlClient",
                Metadata = @"your metadata string",
                ProviderConnectionString = connectionString
            };
            return builder.ConnectionString;
        }
    }
