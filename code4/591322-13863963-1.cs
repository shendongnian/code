    using (gasstationEntities ctx = new gasstationEntities(Resources.CONS))
    {
       using (var scope = new TransactionScope())
       {
          [... your code...]
    
          scope.Complete();
       }
    }
