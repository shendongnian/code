    using(TransactionScope ts=new TransactionScope)
    {
      ...
      if (cond)
      {
        ts.Complete();
      }
      else
      {
        ts.Dispose(); // makes it clear you're rolling back the transaction
      }
    }
