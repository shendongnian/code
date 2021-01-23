    double result;
    using (var dbConn = new SqlConnection("server=myserver;database=mydb;integrated security=sspi;"))
    using (SqlCommand dbCmd = dbConn.CreateCommand())
    {
        dbConn.Open();
        dbCmd.CommandText = "SELECT myfield FROM mytable WHERE anotherField LIKE @p1";
        dbCmd.Parameters.AddWithValue("@p1", "somevalue");
        using (SqlDataReader reader = dbCmd.ExecuteReader())
        {
            if (reader.Read())
            {
                result = reader["myField"] == DBNull.Value ? -1 : Convert.ToDouble(reader["myField"]);
            }
        }
    }
