    //declare the transaction options
    var transactionOptions = new System.Transactions.TransactionOptions();
    //set it to read uncommited
    transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
    //create the transaction scope, passing our options in
    using (var transactionScope = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Required, transactionOptions))
    {
        //declare our context
        using (var context = new MyEntityConnection())
        {
            //any reads we do here will also read uncomitted data
            //...
            //...
        }
        //don't forget to complete the transaction scope
        transactionScope.Complete();
    }
