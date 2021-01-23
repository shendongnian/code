    using (cmd command = new SqlCommand())
    {
        string sql = "Select * from table where projid=@UserEnteredProjid";
        cmd.Connection = conn;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = sql;
        cmd.Parameters.AddWithValue("UserEnteredProjid", your_value_here);      
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
	    //do something;
        }
    }
