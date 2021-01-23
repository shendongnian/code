    string cmdString="INSERT INTO books (name,author,price) VALUES (@val1, @va2, @val3)";
    string connString = "your connection string";
    using (SqlConnection conn = new SqlConnection(connString))
    {
    	using (SqlCommand comm = new SqlCommand())
    	{
    		comm.Connection = conn;
    		comm.CommandString = cmdString;
    		comm.Parameters.AddWithValue("@val1", txtbox1.Text);
    		comm.Parameters.AddWithValue("@val2", txtbox2.Text);
    		comm.Parameters.AddWithValue("@val3", txtbox3.Text);
    		try
    		{
    			conn.Open();
    			comm.ExecuteNonQuery();
    		}
    		Catch(SqlException e)
    		{
    			// do something with the exception
    			// don't hide it
    		}
    	}
    }
