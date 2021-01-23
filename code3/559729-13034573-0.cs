    using(TransactionScope scope = new TransactionScope())
    {
      // init connection, command etc.
      ...
      insertCommand.ExecuteNonQuery();
    
      ...
      updateCommand.ExecuteNonQuery();
      scope.Complete();
    }
