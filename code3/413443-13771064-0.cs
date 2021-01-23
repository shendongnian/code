    private Dictionary<string, int> database = new Dictionary<string, int>();
    private object databaseLock = new object();
    public void AddOrUpdate(string item)
    {
        lock (databaseLock)
        {
            if (Exists(item))
                database.Add(item, 1);
            else
                ++database[item];
        }
    }
    public bool Exists(string item)
    {
        lock (databaseLock)
        {
            //... Maybe some pre-processing of the key or item...
            return database.ContainsKey(item);
        }
    }
