    try
    {
        using(MySqlConnection cn = new  MySqlConnection(connection.ConnectionString))
        {        
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = cn; 
            cmd.CommandText = "UPDATE test SET status_id = 1 WHERE test_id = 1";
            cn.Open();
            int numRowsUpdated = cmd.ExecuteNonQuery();
            cmd.Dispose(); 
         }
    }
