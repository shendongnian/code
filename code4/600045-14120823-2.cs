    string user = "1234";
    string strSQL = "Select * From [User] where UserId = @userID";
    (SqlConnection cnn = new SqlConnection("connection string here"))
    (
    	(SqlCommand myCommand = new SqlCommand(strSQL, cnn))
    	{
    		myCommand.AddWithValue("@userID", user);
    		using (SqlDataReader reader = myCommand.ExecuteReader())
    		{
    			while (reader.Read())
    			{
    				Console.WriteLine(reader["columnName"].ToString();
    			}
    		}
    	}
    }
