    using (var scope = new TransactionScope())
    {
      using (var connection = (SqlConnection)customerTable.OpenConnection())
       {
        //
       }
      scope.Complete();
    }
