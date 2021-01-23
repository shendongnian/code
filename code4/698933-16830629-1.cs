    public static T Get<T>(this NameValueCollection collection, string name) where T : struct
    {
        T v = default(T);
        dynamic indicator = v;
    
        return GetValue(collection, name, indicator);
    }
    
    static int GetValue(NameValueCollection collection, string name, int indicator)
    {
        return 110;
    }
    
    static DateTime GetValue(NameValueCollection collection, string name, DateTime indicator)
    {
        return DateTime.Now;
    }
    
    // ... other helper parsers
    // if nothing else matched
    static object GetValue(NameValueCollection collection, string name, object indicator)
    {
        return indicator;
    }
