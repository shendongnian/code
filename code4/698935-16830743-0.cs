    private static Dictionary<Type, Func<NameValueCollection, string, T>> _typeMap = new Dictionary<Type, Func<NameValueCollection, string, T>>();
    static Constructor()
    {
        _typeMap[typeof(DateTime)] = (nvc, name) => { return (T)GetDateTime(nvc, name); };
        // etc
    }
    public static T Get<T>(this NameValueCollection collection, string name) where T : struct
    {
        return _typeMap[typeof(T)](collection, name);
    }
