    public Dictionary<string, object> GetProperties<T>(T classObj)
    {
        return typeof(T).GetProperties()
                .ToDictionary(p => p.Name, p => p.GetValue(classObj, null));
    }
