    public static class TransactionScopeBuilder
    {
        /// <summary>
        /// Creates a transactionscope with ReadCommitted Isolation, the same level as sql server
        /// </summary>
        /// <returns>A transaction scope</returns>
        public static TransactionScope CreateReadCommitted()
        {
            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
                Timeout = TransactionManager.DefaultTimeout
            };
            return new TransactionScope(TransactionScopeOption.Required, options);
        } 
    }
