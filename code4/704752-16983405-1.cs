        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConnectionString;
        insertCommand.Connection = con;
        con.Open();
        affectedRows = insertCommand.ExecuteNonQuery();
        con.Close();
