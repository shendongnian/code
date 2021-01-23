    public async Task GetCompoundDepositionInfoAsync(CancellationToken cancellationToken)
    {
    	parameters.cmd = new System.Data.SqlClient.SqlCommand("www.GetCompoundDepositionInfo", new System.Data.SqlClient.SqlConnection(parameters.connectionstring));
    	parameters.cmd.CommandType = System.Data.CommandType.StoredProcedure;
    	parameters.cmd.Parameters.AddWithValue("@CompoundID", parameters.CompoundID);
    	using (var connection = new SqlConnection(parameters.connectionstring))
    	using (var command = new SqlCommand(query, connection))
    	{
    		await connection.OpenAsync(cancellationToken);
    		using (var reader = await command.ExecuteReaderAsync(cancellationToken))
    		{
    			if (await reader.ReadAsync(cancellationToken))
    			{
    				lblDeposited.Text = string.Concat("at ", reader.GetDateTime(0).ToShortDateString(), " by ", 	reader.GetString(1));
    			}
    		}
    	}
    }
