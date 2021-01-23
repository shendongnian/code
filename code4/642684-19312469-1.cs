    using (new TransactionScope(TransactionScopeOption.Required, new
            TransactionOptions { IsolationLevel = IsolationLevel.Chaos }))
        using (new TransactionScope(TransactionScopeOption.Required, new
                TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
            Console.WriteLine("this will not be printed");
