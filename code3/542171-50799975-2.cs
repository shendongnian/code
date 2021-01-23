        // create connection
        OracleConnection con = new OracleConnection();
        // create connection string using builder
        OracleConnectionStringBuilder ocsb = new OracleConnectionStringBuilder();
        ocsb.Password = "autumn117";
        ocsb.UserID = "john";
        ocsb.DataSource = "database.url:port/databasename";
        // connect
        con.ConnectionString = ocsb.ConnectionString;
        con.Open();
        Console.WriteLine("Connection established (" + con.ServerVersion + ")");
