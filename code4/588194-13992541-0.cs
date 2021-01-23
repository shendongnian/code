    var transactionOptions = new System.Transactions.TransactionOptions();
    transactionOptions.Timeout = new TimeSpan(0, 0, 30);
    transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
    using (var transactionScope = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Required, transactionOptions))
    {
    ...
    }
