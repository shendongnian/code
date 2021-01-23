    using System.Transactions;    
    ....    
    using (var transactionScope = new TransactionScope())
    {
        DoYourDapperWork();
        transactionScope.Complete();
    }
