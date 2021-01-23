    TransactionOptions TransOpt = New TransactionOptions();
    TransOpt.IsolationLevel = System.Transactions.IsolationLevel.Serializable;
    using(TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, TransOptions))
    {
    ...
    }
