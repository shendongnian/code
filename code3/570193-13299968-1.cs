    using(MySqlConnection sqlCon = new MySqlConnection(MyConnectionString))
    {
    	using (MySqlCommand cmd = new MySqlCommand())
    	{
    		cmd.Connection = sqlCon;
    		cmd.CommandType = CommandType.Text;
    		cmd.CommandText = "SELECT * FROM table1 WHERE username = @user AND password = @pass";
    		cmd.Parameters.AddWithValue("@user", userId);
    		cmd.Parameters.AddWithValue("@pass", password);
    		using (MySqlDataAdapter adap = new MySqlDataAdapter(cmd))
    		{
    			try
    			{
    				DataSet ds = new DataSet();
    				adap.Fill(ds);
    			}
    			catch (MySqlException e)
    			{
    				// do something with the exception
    				// don't hide it!
    			}
    		}
    	}
    }
