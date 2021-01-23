    string sql = "INSERT INTO MinisterTable(MinisterName) VALUES(@MinisterName);";
    using(var con = new OleDbConnection(connectionString))
    using(var cmd = new OleDbCommand(sql, con))
    {
        cmd.Parameters.AddWithValue("@MinisterName", drpMinisters.SelectedValue);
        con.Open();
        cmd.ExecuteNonQuery();
    }
