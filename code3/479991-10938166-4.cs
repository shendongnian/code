    private static Dictionary<string, Type> _knownTypes =
        new Dictionary<string, Type>();
    private static GetType(string name)
    {
        string fullName = typeof(CrawlerBase).Namespace
            + "." + name;
        
        if (_knownTypes.ContainsKey(fullName))
            return _knownTypes[fullName];
    
        Type type = Type.GetType(fullName);
        _knownTypes.Add(fullName, type);
    
        return type;
    }
