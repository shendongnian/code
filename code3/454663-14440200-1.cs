    private static EntityConnection CreateConnection(string connectionString)
    {
        // Find the name of the shared connection string.
        const string appSettingKey = "SharedConnectionStringName";
        string sharedConnectionStringName = ConfigurationManager.AppSettings[appSettingKey];
        if (string.IsNullOrEmpty(sharedConnectionStringName))
        {
            throw new Exception(string.Format(
                "Shared connection not configured. " +
                "Please add a setting called \"{0}\" to the \"appSettings\" " +
                "section of the configuration file.", appSettingKey));
        }
        // Create a (plain old database) connection using the shared connection string.
        ConnectionStringSettings backendSettings =
            ConfigurationManager.ConnectionStrings[sharedConnectionStringName];
        if (backendSettings == null)
        {
            throw new Exception(string.Format(
                "Invalid connection string name \"{0}\" in appSetting \"{1}\"",
                sharedConnectionStringName, appSettingKey));
        }
        System.Data.Common.DbConnection dbConn =
            Database.DefaultConnectionFactory.CreateConnection(
            backendSettings.ConnectionString);
        // Create a helper EntityConnection object to build a MetadataWorkspace out of the
        // csdl/ssdl/msl parts of the generated EF connection string for this DbContext.
        EntityConnection wsBuilder = new EntityConnection(connectionString);
    
        // Merge the specific MetadataWorkspace and the shared DbConnection into a new EntityConnection.
        return new EntityConnection(wsBuilder.GetMetadataWorkspace(), dbConn);
    }
