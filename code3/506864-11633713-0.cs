    string sql = "select * from mytable where MyField LIKE ? and MyOtherField = ?";
    // Dapper
    using (OleDbConnection dbConn = new OleDbConnection("your connection string))
    {
        dbConn.Open();
        var result = dbConn.Query(sql, new { MyField = "some value", MyOtherField = 3 });
        foreach (dynamic myrow in result)
        {
            // you can get at your table rows using myrow.MyField, myrow.SomeOtherField etc
            // To avoid myrow being dynamic, call dbConn.Query<T> where T is some type you 
            // define that matches your table definition
        }
    }
    // The "old-fashioned" way
    using (OleDbConnection dbConn = new OleDbConnection("your connection string))
    using (OleDbCommand dbCmd = dbConn.CreateCommand())
    {
        dbConn.Open();
        dbCmd.CommandText = sql;
        dbCmd.Parameters.AddWithValue("MyField", "some value"));
        dbCmd.Parameters.AddWithValue("MyOtherField", 3));
        OleDbDataReader reader = dbCmd.ExecuteReader();
        while (reader.Read())
        {
            string myfield = reader["myfield"] == DBNull.Value ? null : (string)reader["myfield"];
            int SomeOtherField = reader["someotherfield"] == DBNull.Value ? 0 : (int)reader["someotherfield"];
        }
    }
