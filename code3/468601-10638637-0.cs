    var p = GetProperties(obj);
    var m = GetMethods(obj);    
-
    public Dictionary<string,object> GetProperties<T>(T obj)
    {
        return typeof(T).GetProperties().ToDictionary(p=>p.Name,p=>p.GetValue(obj,null));
    }
    public MethodInfo[] GetMethods<T>(T obj)
    {
        return typeof(T).GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
    }
