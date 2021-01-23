    static readonly object syncRoot = new object();
    static Dictionary<string, JobData> cache;
    static void Initialize()
    {
        if (cache == null)
        {
            lock (syncRoot)
            {
                if (cache == null)
                {
                    cache = LoadFromDatabase();
                }
            }
        }
    }
