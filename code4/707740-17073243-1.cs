	public static Dictionary<string, object>  ExecSproc(string connectionString, string proc, IEnumerable<SqlParameter> parameters)
		{
		SqlCommand  command = null;
		try
			{
			SqlConnection  connection = GetConnection(connectionString);
			// Build the command
			command                = new SqlCommand(proc, connection);
			command.CommandTimeout = TimeOutSeconds;
			command.CommandType    = CommandType.StoredProcedure;
			// Append parameters
			SqlParameter  retValue = new SqlParameter("Return value", null);
			retValue.Direction = ParameterDirection.ReturnValue;
			command.Parameters.Add(retValue);
			if (parameters != null)
				foreach (SqlParameter param in parameters)
					command.Parameters.Add(param);
			// GO GO GO!
			command.ExecuteNonQuery();
			// Collect the return value and out parameters
			var  outputs = new Dictionary<string, object>();
			foreach (SqlParameter param in command.Parameters)
				if (param.Direction != ParameterDirection.Input)
					outputs.Add(param.ParameterName, param.Value);
			return outputs;
			}
		finally
			{
			if (command != null)
				{
				command.Cancel();  // This saves some post-processing which we do not need (out vars and a row count)
				command.Dispose();
				}
			}
		}
