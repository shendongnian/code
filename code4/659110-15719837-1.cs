    string connStr = "connection string here";
    string insertStatement = @"INSERT INTO Orders 
    			Values (@ordID, @custID, @custName, GETDATE())";
    			
    using (SqlConnection conn = new SqlConnection(connStr))
    {
    	using (SqlCommand comm = new SqlCommand())
    	{
    		comm.Connection = conn;
    		comm.CommandType = CommandType.Text;
    		comm.CommandText = insertStatement;
    		comm.Parameters.AddWithValue("@ordID", OrderId.Text);
    		comm.Parameters.AddWithValue("@custID", IDCustTextBox.Text);
    		comm.Parameters.AddWithValue("@custName", CustName.Text);
    		try
    		{
    			conn.Open();
    			conn.ExecuteNonQuery();
    		}
    		catch(SqlException ex)
    		{
    			// do something with the exception
    			// ex.ToString()
    			// don't hide it
    		}
    	}
    }
