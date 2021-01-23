    using(SqlConnection con = new SqlConnection("connection string"))
    {
    
    	con.Open();
    
    	using(SqlCommand cmd = new SqlCommand("SELECT * FROM SomeTable", connection))
        {
    		using (SqlDataReader reader = cmd.ExecuteReader())
    		{
    			if (reader != null)
    			{
    				while (reader.Read())
    				{
    				    //do something
    				}
    			}
    		} // reader closed and disposed up here
    		
    	} // command disposed here
    	
    } //connection closed and disposed here
      
 
