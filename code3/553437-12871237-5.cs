    using (SqlConnection conn = new SqlConnection("connectionstringhere"))
    {
    	using (SqlCommand comm = new SqlCommand())
    	{
    		comm.Connection = conn;
    		comm.CommandText = "your query";
    		comm.CommandType = CommandType.Text;
         	// comm.Parameters.AddWithValue("@paramName","value"); // if you have parameters
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
