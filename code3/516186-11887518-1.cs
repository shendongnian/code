    SqlConnectionStringBuilder cb = new SqlConnectionStringBuilder(connectionString);
    SqlConnection sqlConn = new SqlConnection();
    if (sqlConn.State != ConnectionState.Open)
    {
        GPConnection.Startup();
        var gpconn = new GPConnection();
        gpconn.Init(<Key1>, <Key2>);
        try
        {
            sqlConn.ConnectionString = string.Format("database={0}", cb.InitialCatalog);
            gpconn.LoginCompatibilityMode = false;
            gpconn.Connect(sqlConn, cb.DataSource, cb.UserID, cb.Password);
            if (gpconn.ReturnCode != 1)
                throw new AuthenticationException("Could not authenticate with the GP    credentials.");
        }
        catch (System.Runtime.InteropServices.SEHException)
        {
            throw new AuthenticationException("Could not authenticate with the GP credentials.");
        }
    }
