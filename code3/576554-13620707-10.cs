    static ConcurrentDictionary<Type, Dictionary<string, MethodInfo>> cacheOfGetMethodByString
        = new ConcurrentDictionary<Type, Dictionary<string, MethodInfo>>();
    public static MethodInfo GetMethodByString(
        this Type type, string methodString)
    {
        var typeData = cacheOfGetMethodByString
            .GetOrAdd(type, CreateTypeData);
        MethodInfo mi;
        typeData.TryGetValue(methodString, out mi);
        return mi;
    }
    public static Dictionary<string, MethodInfo> CreateTypeData(Type type)
    {
        var dic = new Dictionary<string, MethodInfo>();
        foreach (var eachMi in type.GetMethods())
            dic.Add(MethodToString(eachMi), eachMi);
        return dic;
    }
