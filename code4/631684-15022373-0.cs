    /// <summary>
    /// Changes the database all the queries in a queries table adapter connect to
    /// </summary>
    /// <typeparam name="IQA">The type of the queries table adapter</typeparam>
    /// <param name="InstanceQueriesAdapter">The instance of the queries table adapter</param>
    /// <param name="sqlDatabaseName">The name of the database the queries table adapter queries should connect to</param>
    public static void GetInstanceQueriesAdapter<IQA>(ref IQA InstanceQueriesAdapter, string sqlDatabaseName)
    {
    	try
    	{
    		FieldInfo qAdapterCommandCollection = InstanceQueriesAdapter.GetType().GetField("_commandCollection", BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.NonPublic);
    		MethodInfo initCC = InstanceQueriesAdapter.GetType().GetMethod("InitCommandCollection", BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.NonPublic);
    
    		if (qAdapterCommandCollection != null && initCC != null)
    		{
    			initCC.Invoke(InstanceQueriesAdapter, null);
    
    			IDbCommand[] qaCC = (IDbCommand[])qAdapterCommandCollection.GetValue(InstanceQueriesAdapter);
    
    			foreach (SqlCommand singleCommand in qaCC)
    			{
    				SqlConnection newSQLConnection = singleCommand.Connection;
    
    				SqlConnectionStringBuilder csBulider = new SqlConnectionStringBuilder(newSQLConnection.ConnectionString);
    
    				csBulider.InitialCatalog = sqlDatabaseName;
    
    				newSQLConnection.ConnectionString = csBulider.ConnectionString;
    
    				singleCommand.Connection = newSQLConnection;
    			}
    
    			qAdapterCommandCollection.SetValue(InstanceQueriesAdapter, qaCC);
    		}
    		else
    		{
    			throw new Exception("Could not find command collection.");
    		}
    	}
    	catch (Exception _exception)
    	{
    		throw new Exception(_exception.ToString());
    	}
    }
