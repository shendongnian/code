    Monitor.Enter (SyncRoot);
    try
    {
        return value;
    }
    finally { Monitor.Exit (SyncRoot); }
