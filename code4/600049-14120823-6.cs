    string user = "1234";
    string strSQL = "Select * From [User] where UserId = @userID";
    using (SqlConnection cnn = new SqlConnection("connection string here"))
    {
    	using (SqlCommand myCommand = new SqlCommand(strSQL, cnn))
    	{
    		myCommand.Parameters.AddWithValue("@userID", user);
    		using (SqlDataReader reader = myCommand.ExecuteReader())
    		{
    			while (reader.Read())
    			{
    				Console.WriteLine(reader["columnName"].ToString());
    			}
    		}
    	}
    }
