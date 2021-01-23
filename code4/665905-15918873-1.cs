    string connStr = "connection string here";
    string sqlStatement = "INSERT INTO DR_OZLUK VALUES (3, @val1, @val2, 3, @val3, 1)";
    using (SqlConnection conn = new SqlConnection(connStr))
    {
    	using(SqlCommand comm = new SqlCommand())
    	{
    		comm.Connection = conn;
    		comm.CommandText = sqlStatement;
    		comm.CommandType = CommandType.Text;
    		
    		comm.Parameters.AddWithValue("@val1", ddlDoktor.SelectedValue);
    		comm.Parameters.AddWithValue("@val2", belgeid);
    		comm.Parameters.AddWithValue("@val3", str);
    		
    		try
    		{
    			conn.Open();
    			comm.ExecuteNonQuery();
    		}
    		catch(SqlException e)
    		{
    			// do something with the exception
    			// do not hide it
    			// e.Message.ToString()
    		}
    	}
    }
