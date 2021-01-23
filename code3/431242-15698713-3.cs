    public static Dictionary<string, object> ToPropertyDictionary(this object obj)
    {
        var dictionary = new Dictionary<string, object>();
        foreach (var propertyInfo in obj.GetType().GetProperties())
            if (propertyInfo.CanRead && propertyInfo.GetIndexParameters().Length == 0)
                dictionary[propertyInfo.Name] = propertyInfo.GetValue(obj, null);
        return dictionary;
    }
