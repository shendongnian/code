    public static T GetValue<T>(this Dictionary<T, Dictionary<T,T>> dict, 
                                T key, T subKey) where T: class
    {
        T value = dict[key] != null ? dict[key][subKey] : null;
        return value;
    }
    string value = myDict.GetValue("foo", "bar");
