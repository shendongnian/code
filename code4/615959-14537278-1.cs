    string _connStr = "connectionString here";
    string _query = "INSERT INTO [user] (Firstname,Lastname,Email,Pass,Type) values (@first,@last,@email,@pass,@type)";
    using (SqlConnection conn = new SqlConnection(_connStr))
    {
    	using (SqlCommand comm = new SqlCommand())
    	{
    		comm.Connection = conn;
    		comm.CommandType = CommandType.Text;
    		comm.CommandText = _query;
    		comm.Parameters.AddWithValue("@first", txtfirst.Text);
    		comm.Parameters.AddWithValue("@last", txtlast.Text);
    		comm.Parameters.AddWithValue("@email", txtemail.Text);
    		comm.Parameters.AddWithValue("@pass", txtpass.Text);
    		comm.Parameters.AddWithValue("@type", "customer");
    		try
    		{
    			conn.Open();
    			comm.ExecuteNonQuery();
    		}
    		catch(SqlException ex)
    		{
    			// other codes here
    			// do something with the exception
    			// don't swallow it.
    		}
    	}
    }
