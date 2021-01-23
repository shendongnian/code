    public void displayDBDetails()
    {
        SqlConnection sqlConn = new SqlConnection(string yourConnectionString);
        sqlConn.Open();
        string dbName = sqlConn.Database.ToString();
        string dbStatus = sqlConn.State.ToString();
        string dbServerVersion = sqlConn.ServerVersion.ToString();
        etc.....
    }
