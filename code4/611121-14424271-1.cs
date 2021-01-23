    private Dictionary<Type, PropertyInfo[]> propertyCache;
    // ...
    public PropertyInfo[] GetProperties(Type t)
    {
        if (propertyCache.ContainsKey(t))
        {
            return propertyCache[t];
        }
        else
        {
            var propertyInfos = t.GetProperties();
            propertyCache[t] = propertyInfos;
            return propertyInfos;
        }
    }
