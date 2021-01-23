    private static JArray RemoveValue(JArray oldArray, dynamic obj)
    {
        List<string> newArray= oldArray.ToObject<List<string>>();
        newArray.Remove(obj); 
        return JArray.FromObject(newArray);
    }
