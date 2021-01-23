    var yourObjectList = List<YourObject>(){.....}
    string s = JsonConvert.SerializeObject(GetObjectArray(yourObjectList));
    public static IEnumerable<object> GetObjectArray<T>(IEnumerable<T> obj)
    {
        return obj.Select(o => o.GetType().GetProperties().Select(p => p.GetValue(o, null)));
    }
