    string connStr = "connection string here";
    string insertStr = @"INSERT INTO sales (price, user, date)
    						VALUES (@price, @user, @date)";
    using (MySqlConnection conn = new MySqlConnection(connStr))
    {
    	using (MySqlCommand comm = new MySqlCommand())
    	{
    		comm.Connection = conn;
    		comm.CommandType = CommandType.text;
    		comm.CommandText = insertStr;
    		comm.Parameters.AddWithValue("@price", txtQuant.Text);
    		comm.Parameters.AddWithValue("@user", txtLog.Text);
    		comm.Parameters.AddWithValue("@date", DateTime.Now);
    		try
    		{
    			conn.Open();
    			comm.ExecuteNonQuery();
    		}
    		catch(MySqlException ex)
    		{
    			// don't hide the exception
    			// do something
    			// ex.ToString()
    		}
    	}
    }
