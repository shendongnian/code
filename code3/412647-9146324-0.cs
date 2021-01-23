    foreach (string DatabaseConfig in DataHoldingClass.Server_Database_Config) 
    { 
        string[] splitConfig = DatabaseConfig.Split('|');
        string connectionString = "server=" + splitConfig[1] + ";database =" + splitConfig[0] +
                   ";Trusted_Connection=Yes;persist security info=False;connection timeout=500";
        using (SqlConnection cnn = new SqlConnection(connectionString))
        {
            cnn.Open();
            // do work....
        }
    }
