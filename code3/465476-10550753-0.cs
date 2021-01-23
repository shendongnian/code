    System.Data.SqlClient.SqlConnectionStringBuilder connBuilder = new System.Data.SqlClient.SqlConnectionStringBuilder();
    
    connBuilder.ConnectionString = connectionString;
    
    string server = connBuilder.DataSource;           //-> this gives you the Server name.
    string database = connBuilder.InitialCatalog;     //-> this gives you the Db name.
