    static SqlConnection CreateConnection()
    {
        if (ConfigurationManager.ConnectionStrings["IMS"] == null)
        {
            throw new Exception("Connection string not found in the configuration file.");
        }
        var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["IMS"].ConnectionString);
        try
        {
            sqlConnection.Open();
        }
        catch (Exception exception)
        {
            throw new Exception("An error occured while connecting to the database. See innerException for details.", exception);
        }
        return sqlConnection;
    }
