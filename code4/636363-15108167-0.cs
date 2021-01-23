    public static Dictionary<String, String> ConvertAnyToDictionary<T>(T value) where T : class {
        var properties = typeof(T).GetFields();
        return properties.ToDictionary(x => x.Name, 
                                       x => x.GetValue(value).ToString());
    }
