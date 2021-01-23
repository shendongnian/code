    using (TransactionScope transaction = new TransactionScope()){
      var one = new DbRecord();
      var two = new DbRecord();
      var thr = new DbRecord();
      context.DbRecords.Add(one);
      context.SaveChanges();
      context.DbRecords.Add(two);
      context.SaveChanges();
      context.DbRecords.Add(thr);
      context.SaveChanges();
      // various unrelated operations w/context...
      context.SaveChanges();
      transaction.Complete();
    }
