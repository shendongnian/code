    // transaction scope
    using (var scope = new TransactionScope(... ,
      TransactionScopeAsyncFlowOption.Enabled))
    {
      // connection
      using (var connection = new SqlConnection(_connectionString))
      {
        // open connection asynchronously
        await connection.OpenAsync();
        using (var command = connection.CreateCommand())
        {
          command.CommandText = ...;
          // run command asynchronously
          using (var dataReader = await command.ExecuteReaderAsync())
          {
            while (dataReader.Read())
            {
              ...
            }
          }
        }
      }
      scope.Complete();
    }
