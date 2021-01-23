    using (IDbConnection db = DatabaseFactory.OpenDbConnection()) {
        using (var transaction = db.BeginTransaction(IsolationLevel.ReadCommitted)) {
            // do stuff here
        }
    }
