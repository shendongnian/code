    public static Dictionary<String, String> ConvertAnyToDictionary<T>(T value) where T : class {
        var fields = typeof(T).GetFields();
        var properties = typeof(T).GetProperties();
        var dict1 = fields.ToDictionary(x => x.Name, x => x.GetValue(value).ToString());
        var dict2 = properties.ToDictionary(x => x.Name, x => x.GetValue(value, null).ToString());
        return dict1.Union(dict2).ToDictionary(x => x.Key, x=> x.Value);
    }
