    private static string ConnectionString(string dbFileName)
        {
            // Specify the provider name, server and database.
            const string providerName = "FirebirdSql.Data.FirebirdClient";
            const string metaData = "res://*/RcModel.csdl|res://*/RcModel.ssdl|res://*/RcModel.msl";
            // Initialize the EntityConnectionStringBuilder.
            EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();
            //Set the provider name.
            entityBuilder.Provider = providerName;
            FbConnectionStringBuilder sqlBuilder = new FbConnectionStringBuilder();
            sqlBuilder.UserID = "sysdba";
            sqlBuilder.Password = "masterkey";
            sqlBuilder.DataSource = @"127.0.0.1";
            sqlBuilder.Database = dbFileName;
            sqlBuilder.Dialect = 3;
            sqlBuilder.Charset = "UTF8";
            sqlBuilder.ServerType = FbServerType.Default;
            // Set the provider-specific connection string.
            entityBuilder.ProviderConnectionString = sqlBuilder.ConnectionString;
            entityBuilder.Metadata = metaData;
            return entityBuilder.ToString();
        }
