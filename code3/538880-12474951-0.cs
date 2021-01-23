    public static Dictionary<string, string> GetFieldValues(object obj)
    {
        var result = obj.GetType()
                        .GetFields(BindingFlags.Public | BindingFlags.Static)
                        .Where(f => f.FieldType == typeof(string))
                        .ToDictionary(f => f.Name,
                                      f => f.GetValue(null));
    }
