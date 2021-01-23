    private static Dictionary<string, object> cacheItems = new Dictionary<string, object>();
    private static object locker = new object();
    public Dictionary<string, object> CacheItems
    {
        get{ return cacheItems; }
        set{ cacheItems = value; }
    }
    SomeFunction()
    {
        ...
        lock(locker)
        {
            CacheItems["VariableName"] = SomeObject;
        }
        ...
    }
