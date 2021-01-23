    var resultValues = new List<string>();
    using (var dbConn = new SqlConnection("server=myserver;database=mydb;integrated security=sspi;"))
    using (SqlCommand dbCmd = dbConn.CreateCommand())
    {
        dbConn.Open();
        dbCmd.CommandText = "SELECT myfield FROM mytable WHERE anotherField LIKE @p1";
        dbCmd.Parameters.AddWithValue("@p1", "somevalue");
        using (SqlDataReader reader = dbCmd.ExecuteReader())
        {
            while (reader.Read())
            {
                resultValues.Add(reader["myField"] == DBNull.Value ? null : (string)reader["myField"]);
            }
        }
    }
