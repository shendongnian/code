    /// <summary>
    /// Executes a SqlCommand that expects four result sets and binds the results to the given models
    /// </summary>
    /// <typeparam name="T1">Type: the type of object for the first result set</typeparam>
    /// <typeparam name="T2">Type: the type of object for the second result set</typeparam>
    /// <returns>List of Type T: the results in a collection</returns>
    public void ExecuteAs<T1, T2>(SqlCommand command, List<T1> output1, List<T2> output2)
    {
    	string _modelName1 = typeof(T1).Name;
    	string _modelName2 = typeof(T2).Name;
    	string _commandText = command.CommandText;
    
    	using (SqlConnection connection = GetOpenConnection())
    	{
    		using (command)
    		{
    			command.Connection = connection;
    			command.CommandTimeout = _defaultCommandTimeout;
    			using (SqlDataReader reader = command.ExecuteReader())
    			{
    				while (reader.Read())                                               // Call Read before accessing data.
    				{
    					ReadAs<T1>(reader, _modelName1, output1, _commandText);
    				}
    
    				reader.NextResult();
    
    				while (reader.Read())                                               // Call Read before accessing data.
    				{
    					ReadAs<T2>(reader, _modelName2, output2, _commandText);
    				}
    			} // end using reader
    		} // end using command
    	} // end using connection
    }	
