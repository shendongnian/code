    SqlCommand command = new SqlConnection("[The connection String goes here]").CreateCommand();
    
    try
    {
    	command.Parameters.Add(new SqlParameter() { ParameterName = "ParameterA", Direction = ParameterDirection.Input, Value = "Some value" });
    
    	command.Parameters.Add(new SqlParameter() { ParameterName = "ReturnValue", Direction = ParameterDirection.ReturnValue });
    
    	command.CommandText = "[YourSchema].[YourProcedureName]";
    
    	command.CommandType = CommandType.StoredProcedure;
    
    	command.Connection.Open();
    	command.ExecuteNonQuery();
    }
    catch (Exception ex)
    {
    	//TODO: Log the exception and return the relevant result.
    }
    finally
    {
    	if (command.Connection.State != ConnectionState.Closed)
    
    		command.Connection.Close();
    
    	SqlConnection.ClearPool(command.Connection);
    
    	command.Connection.Dispose();
    
    	command.Dispose();
    }
