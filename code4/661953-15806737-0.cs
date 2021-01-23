    string sqlStatement = "INSERT INTO Rates_Table(ISO, Amount, Rate, Date) VALUES (@iso, @Amount, @rate, @date)";
    using (SqlConnection conn = new SqlConnection(connStr))
    {
    	using(SqlCommand comm = new SqlCommand())
    	{
    		comm.Connection = conn;
    		comm.CommandText = sqlStatement;
    		comm.CommandType = CommandType.Text;
    		
    		comm.Parameters.AddWithValue("@iso", '-- value --');
    		comm.Parameters.AddWithValue("@Amount", '-- value --');
    		comm.Parameters.AddWithValue("@rate", '-- value --');
    		comm.Parameters.AddWithValue("@date", '-- value --');
    		try
    		{
    			conn.Open();
    			int _affected = comm.ExecuteNonQuery();
    		}
    		catch(SqlException e)
    		{
    			// do something with the exception
    			// do not hide it
    			// e.Message.ToString()
    		}
    	}
    }
