    static void Main(string[] args)
    {
        var entities = new MyEntities();
        // Execute the SP to get the isolation level
        string level = entities.TempTestIsolation().First().Value;
        Console.WriteLine("Without a transaction: " + level);
    
        var to = new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.Snapshot };
        using (var ts = new TransactionScope(TransactionScopeOption.Required, to))
        {
            // Execute the SP to get the isolation level
            level = entities.TempTestIsolation().First().Value;
            Console.WriteLine("With IsolationLevel.Snapshot: " + level);
        }
    
        to = new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted };
        using (var ts = new TransactionScope(TransactionScopeOption.Required, to))
        {
            // Execute the SP to get the isolation level
            level = entities.TempTestIsolation().First().Value;
            Console.WriteLine("With IsolationLevel.ReadCommitted: " + level);
        }
        Console.ReadKey();
    }
