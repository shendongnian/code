    public DataTable GetDataForSql(string sql, string connectionString)
    {
    	using(SqlConnection connection = new SqlConnection(connectionString))
     	{
    		using(SqlCommand command = new SqlCommand())
    		{
    			command.CommandType = CommandType.Text;
    			command.Connection = connection;
    			command.CommandText = sql;
    			connection.Open();			
    			using(SqlDataReader reader = command.ExecuteReader())
    			{
    				DataTable data = new DataTable();
    				data.Load(reader);
    				return data;
    			}
    			
    		}
    	
    	}
    
    }
