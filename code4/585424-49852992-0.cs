    using (SqlConnection connection = GetConnection())
    {
        connection.Open();
        DataTable dtDatabases = connection.GetSchema("databases");
        //Get database name using dtDatabases["database_name"]
    }
