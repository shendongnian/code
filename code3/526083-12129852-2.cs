    //The method that call the stored procedure
    public void AddComment()
    {
    	using(var connection = new SqlConnection("ConnectionString"))
    	{
    		connection.Open();
    		using(var cmd = new SqlCommane("storedProcedure_Name", connection) { CommandType = CommandType.StoredProcedure })
    		{
    			cmd.Parameters.AddWithValue("@CommentFrom", commandFrom);
    			cmd.Parameters.AddWithValue("@CommentTo", commentTo);
    			//...And  so on
    			
    			cmd.ExecuteNonQuery();
    		}
    	}
    }
