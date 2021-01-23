    var sb = new SqlConnectionStringBuilder() { InitialCatalog = catname,
                                                DataSource = dbname,
                                                UserID = "sa",
                                                Password = "sa" };
    var dbConnection = new SqlConnection(sb.ConnectionString);
