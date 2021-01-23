    public static TransactionScope GetTransaction() {
        var start = DateTime.Now;
        // Log creation time
        m_Queue.Enqueue((DateTime.Now.Subtract(start)).TotalMilliseconds);
        TransactionOptions options = new TransactionOptions();
        options.IsolationLevel = IsolationLevel.ReadCommitted;
        var t = new TransactionScope(TransactionScopeOption.Required, options);
        return t;
    }
