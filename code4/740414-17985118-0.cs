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
        return Blacklist.Contains(ID);
    }
