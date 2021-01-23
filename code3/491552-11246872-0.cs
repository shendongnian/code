    using (var scope = new System.Transactions.TransactionScope())
    {
            ItemDAL itemDAL = new ItemDAL(); 
            SomeOtherItemDAL someOtherItemDAL = new SomeOtherItemDAL(); 
     
            // *** this must be done in one transaction *** 
            itemDAL.Add(item); 
            someOtherItemDAL.Add(someOtherItem); 
    
           scope.Complete()
    }
