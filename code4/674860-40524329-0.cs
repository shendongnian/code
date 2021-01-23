    string connetionString = null;
    connetionString = "server=localhost;database=device_db;uid=root;pwd=123;";
    
    using (MySqlConnection cn = new MySqlConnection(connetionString))
    {
    	try
    	{
    		string query = "INSERT INTO test_table(user_id, user_name) VALUES (?user_id,?user_name);";
    		cn.Open();
    		using (MySqlCommand cmd = new MySqlCommand(query, cn))
    		{
    			cmd.Parameters.Add("?user_id", MySqlDbType.Int32).Value = 123;
    			cmd.Parameters.Add("?user_name", MySqlDbType.VarChar).Value = "Test username";
    			cmd.ExecuteNonQuery();
    		}
    	}
    	catch (MySqlException ex)
    	{
    		MessageBox.Show("Error in adding mysql row. Error: "+ex.Message);
    	}
    }
