    string finish = DropDownListFi.SelectedValue;
    String Name = Request.QueryString["Name"];
    string connStr = @"DataSource=dbedu.cs.vsb.cz\SQLDB;
                       Persist Security Info=True;
                       User ID=*****;
                       Password=*******";
    string sqlStatement = @"UPDATE navaznost_ukolu 
                            SET    finish = @finish 
                            WHERE  Name = @Name";
    using (SqlConnection conn = new SqlConnection(connStr))
    {
    	using(SqlCommand cmd = new SqlCommand())
    	{
    		cmd.Connection = conn;
    		cmd.CommandText = sqlStatement;
    		cmd.CommandType = CommandType.Text;
    		
			cmd.Parameters.Add(new SqlParameter("@finish", finish));
			cmd.Parameters.Add(new SqlParameter("@name", Name));
    		
    		try
    		{
    			conn.Open();
    			cmd.ExecuteNonQuery();
    		}
    		catch(SqlException e)
    		{
    			// do something with the exception
    			// do not hide it
    			// e.Message.ToString()
    		}
    	}
    }
