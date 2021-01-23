    private static HashSet<string> Blacklist = new HashSet<string>();
    private static List<string> IDList = new List<string>();
    private static ReaderWriterLockSlim BlacklistLock = new ReaderWriterLockSlim();
    public static void AddIDToIDList(string ID)
    {
        if (IsIDBlacklisted(ID))
            return;
        lock (IDList)
        {
            IDList.Add(ID);
        }
    }
    public static bool IsIDBlacklisted(string ID)
    {
        BlacklistLock.EnterReadLock();
        try
        {
            return Blacklist.Contains(ID);
        }
        finally
        {
            BlacklistLock.ExitReadLock();
        }
    }
    public static bool AddToIDBlacklist(string ID)
    {
        BlacklistLock.EnterWriteLock();
        try
        {
            return Blacklist.Add(ID);
        }
        finally
        {
            BlacklistLock.ExitWriteLock();
        }
    }
