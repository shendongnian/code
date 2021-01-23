    System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlDbConnection();
        conn.ConnectionString =
        "Data Source=ServerName;" +
        "Initial Catalog=DataBaseName;" +
        "User id=UserName;" +
        "Password=Secret;";
        conn.Open();
