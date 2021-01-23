    --Simple T-Sql Proc
    
    CREATE PROCEDURE usp_OutputRowExample
    	@Count INT OUTPUT
    AS
    BEGIN
    	SELECT * FROM <table>; --Get your entities
    	
    	SELECT @Count = @@ROWCOUNT; --@@ROWCOUNT returns the amount of
                                    --affected rows from the last query
    END
    
    //From C#
    
    public Tuple<IEnumerable<object>, int>> GetObjects()
    {
    	using(var connection = new SqlConnection(_connectionString))
    	{
            connection.Open();
                
    		using(var command = sqlConnection.CreateCommand())
    		{
    			command.CommandText = "usp_OutputRowExample";
    			command.CommandType = CommandType.StoredProcedure;
    			
    			var outputParameter = new SqlParameter("@Output", SqlDbType.Int)
    				{ Direction = ParameterDirection.Output };
    				
    			command.Parameters.Add(outputParameter);
    			
    			using(var reader = command.ExecuteReader())
    			{
    				var entities = new List<entities>();
    				while(reader.Read())
    				{
    					//Fill entities
    				}
    			}
    			
    			var outputCount = outputParameter.Value as int? ?? default(int);
    			
    			return new Tuple<IEnumerable<object>, int>(entities, outputCount);
    		}
    	}
    }
