    private static ReadOnlyDictionary<string, object> _CacheReadOnly;
    private static Dictionary<string, object> _CacheItems;
    public static ctor()
    {
        _CacheItems = new Dictionary<string, object>();
        _CacheReadOnly = new ReadOnlyDictionary(_CacheItems);
    }
    public static IDictionary<string, object> CacheItems
    {
        get
        {
            return CacheReadOnly;
        }
    }
