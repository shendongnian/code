    string connStr = "connection string here";
    string sqlStatement = @"SELECT COUNT(*) TotalCount
							FROM logintable 
							WHERE Users=@user and Pass=@pass";
    using (SqlConnection conn = new SqlConnection(connStr))
    {
    	using(SqlCommand comm = new SqlCommand())
    	{
    		comm.Connection = conn;
    		comm.CommandText = sqlStatement;
    		comm.CommandType = CommandType.Text;
    		
    		comm.Parameters.AddWithValue("@user", txtUser.Text);
    		comm.Parameters.AddWithValue("@pass", txtPass.Text);
			
    		try
    		{
    			conn.Open();
    			int _result = Convert.ToInt32(comm.ExecuteScalar());
				if (_result > 0)
				{
					new Login().Show();
				}
    		}
    		catch(SqlException e)
    		{
    			// do something with the exception
    			// do not hide it
    			// e.Message.ToString()
    		}
    	}
    }
	
