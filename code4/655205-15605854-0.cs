    private Dictionary<Properties,String> PropertyToString = Enum
        .GetValues(typeof(Properties))
        .ToDictionary(v => v, v => Enum.GetName(typeof(Properties), v));
    private Dictionary<String,Properties> StringToProperty = Enum
        .GetValues(typeof(Properties))
        .ToDictionary(v => Enum.GetName(typeof(Properties), v), v => v);
