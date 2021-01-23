    // cs stores previous connection string which came from config
    System.Data.SqlClient.SqlConnectionStringBuilder builder = 
        new System.Data.SqlClient.SqlConnectionStringBuilder(cs);
    builder.InitialCatalog = "NEWDB";
    // you get your database name replaced properly...
    cs = builder.ToString();
