    public SqlConnection GetConnection()
    {
    string connectionString = ConfigurationManager.ConnectionStrings['"' + DatabaseName + '"' ].ConnectionString;
    SqlConnection con = new SqlConnection (connectionString);
    return con;
    }
