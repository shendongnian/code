    using(SqlCeConnection con = new SqlCeConnection(connStr)
    { 
        con.Open(); 
        SqlCeCommand qry = new SqlCeCommand("INSERT INTO TableName (ColName) VALUES (@ColName)", con);
                 
        qry.Parameters.AddWithValue("@ColName", "ColName Value");
        qry.ExecuteNonQuery(); 
    }
