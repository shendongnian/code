    public DBGateway()
    {
        ConnectionStringSettings mySetting = ConfigurationManager.ConnectionStrings["test"];
        if (mySetting == null || string.IsNullOrEmpty(mySetting.ConnectionString))
            throw new Exception("Fatal error: missing connecting string in web.config file");
        conString = mySetting.ConnectionString;
    }
