    string sql = "insert into mytable (MyField, MyOtherField) values (?, ?)";
    // Dapper
    using (OleDbConnection dbConn = new OleDbConnection("your connection string))
    {
        dbConn.Open();
        dbConn.Execute(sql, new { MyField = "some value", MyOtherField = 3 });
    }
    // The "old-fashioned" way
    using (OleDbConnection dbConn = new OleDbConnection("your connection string))
    using (OleDbCommand dbCmd = dbConn.CreateCommand())
    {
        dbConn.Open();
        dbCmd.CommandText = sql;
        dbCmd.Parameters.AddWithValue("MyField", "some value"));
        dbCmd.Parameters.AddWithValue("MyOtherField", 3));
        dbCmd.ExecuteNonQuery(sql);
    }
