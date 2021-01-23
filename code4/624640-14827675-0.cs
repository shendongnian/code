    foreach (var item in transactions)
    {
      if (item.TransactionId > 0) //Update
      {
        var original = context.Transaction.Where(
                                t => t.TransactionId == item.TransactionId)
                              .FirstOrDefault();
    
        original.TransactionType = context.TypeTransaction.Single(
                               p => p.TypeTransactionId == item.TransactionType.TypeTransactionId);
                                
        context.Entry(original).CurrentValues.SetValues(item);
      }
      else //Insert
      {    
        item.TransactionType = context.TypeTransaction.Single(
                               p => p.TypeTransactionId == item.TransactionType.TypeTransactionId);
    
        context.Transaction.Add(item);
      }
    }
    
    context.SaveChanges();
