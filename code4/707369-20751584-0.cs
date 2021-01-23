    using (iDB2Transaction db2Transaction = db2Command.Connection.BeginTransaction(IsolationLevel.Chaos))
    {
      Update/Insert/Delete
    }
    db2Command = iDB2Command
