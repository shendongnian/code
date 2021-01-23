    public static T UnionCombine<T>(IEnumerable<T> values) where T : new() {
        var newItem = new T();
        var properties = typeof(T).GetProperties();
        for (var prop in properties) {
            var pValueFirst = prop.GetValue(values.First(), null);
            var useDefaultValue = values.Skip(1).Any(v=>!(Object.Equals(pValueFirst, prop.GetValue(v, null))));
            if (!useDefaultValue) prop.SetValue(newItem, pValue, null);
        }
        return newItem;
    }
