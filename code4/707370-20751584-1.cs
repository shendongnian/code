    using (iDB2Transaction db2Transaction = db2Command.Connection.BeginTransaction(IsolationLevel.Chaos))
    {
      db2Command.Transaction = db2Transaction;
      Update/Insert/Delete
    }
    db2Command = iDB2Command
