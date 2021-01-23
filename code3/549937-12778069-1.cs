    string DBName = "SELECT count(*) FROM tbl_namelist WHERE name = @name";
    using (MySqlConnection conn = new MySqlConnection("connectionString Here"))
    {
    	using (MySqlCommand comm = new MySqlCommand())
    	{
    		comm.Connection = conn;
    		comm.CommandText = DBName;
    		comm.CommandType = CommandType.Text;
    		comm.Parameters.AddWithValue("@name", name);
    		try
    		{
    			conn.Open();
    			int totalCount = Convert.ToInt32(comm.ExecuteScalar());
    			if (totalCount == 0)
    			{
    				// when zero
    			}
    			else
    			{
    				// when not zero
    			}
    		}
    		catch( MySqlException ex)
    		{
    			// error here
    		}
    	}
    }
