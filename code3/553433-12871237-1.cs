    using (SqlConnection conn = new SqlConnection("connectionstringhere"))
    {
    	using (SqlCommand comm = new SqlCommand())
    	{
    		comm.Connection = conn;
    		comm.CommandText = "you query";
    		comm.CommandType = CommandType.Text;
    		try
    		{
    			conn.Open();
    			comm.ExecuteNonQuery();
    		}
    		catch(SqlException ex)
    		{
    			// error here
    			// ex.Message.Tostring  // holds the error message
    		}
    	}
    }
