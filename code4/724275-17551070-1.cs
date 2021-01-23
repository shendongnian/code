    using (var conn = <GETCONNETIONMETHOD>)
    {
      conn.Open();
      using (var tran = conn.BeginTransaction()) 
      {
        using (var cmd = conn.CreateCommand(
            @"update dbo.outgoingqueue set status = 'C' where transactionID = @id"))
        {
           cmd.Transaction = conn.BeginTransaction();
           var param = cmd.Parameters.Add("@id", typeof(int));
           cmd.Prepare();
           foreach (int id in transactionsToUpdate.ToList())
           {
             param.Value = id;
             cmd.ExecuteNonQuery();
           }
           tran.Commit();
         }
      }
    }
