    public void DisposeSQLite()
    {
        SQLiteConnection.Dispose();
        SQLiteCommand.Dispose();
        GC.Collect();
    }
