    public ConnectionStringSettings getConnection(string server, string database)
    {
        string connection = ConfigurationManager.ConnectionStrings["myConnString"].ToString();
        connection = string.Format(connection, server, database);
        return new ConnectionStringSettings("myConnString", connection);
    }
