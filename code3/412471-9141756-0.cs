    using (var con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
    {
    	con.Open();
    	{
    		using (var command = con.CreateCommand())
    		{
    			command.Connection = conn;
    			command.CommandText = "SELECT * FROM [dbo].[Table] WHERE [c1] = @a AND [c2] = @b";
    			command.Parameters.AddWithValue("@a", aVal);
    			command.Parameters.AddWithValue("@b", bVal);
    			command.CommandType = CommandType.Text;
    
    			using (var reader = command.ExecuteReader())
    			{
    				if (reader.HasRows)
    				{
    					while (reader.Read())
    					{
    						///
    					}
    				}
    				else
    				{
    					///
    				}
    			}
    		}
    	}
    }
