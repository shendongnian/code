    Server sqlServer = new Server(connection);
    Database db = sqlServer.Databases["DbToRestore"];
    if (db != null)
    {
        sqlServer.KillAllProcesses(db.Name);
        db.DatabaseOptions.UserAccess = DatabaseUserAccess.Multiple;
        db.Alter(TerminationClause.RollbackTransactionsImmediately);
    }
    Restore restoreDB = new Restore();
