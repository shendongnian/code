    private static HashSet<string> Blacklist = new HashSet<string>();
    private static ConcurrentBag<string> IDList = new ConcurrentBag<string>();
    
    public static void AddIDToIDList(string ID)
    {
        if (Blacklist.Contains(ID))
        {
            return;
        }
        IDList.Add(ID);
    }
