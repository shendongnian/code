    public void SplitKeyValues(IList source, List<object> keys, List<object> values)
    {
        Type itemType = GetListItemType(source.GetType());
        PropertyInfo[] properties = itemType.GetProperties();
        for (int i = 0; i < source.Count; i++) {
            object item = source[i];
            var itemValues = new List<object>();
            values.Add(itemValues);
            foreach (PropertyInfo prop in properties) {
                if (typeof(IList).IsAssignableFrom(prop.PropertyType) &&
                    prop.PropertyType.IsGenericType) {
                    // We have a List<T> or array
                    Type genericArgType = GetListItemType(prop.PropertyType);
                    if (genericArgType.IsValueType || genericArgType == typeof(string)) {
                        // We have a list or array of a simple type
                        if (i == 0)
                            keys.Add(prop.Name);
                        List<object> subValues = new List<object>();
                        itemValues.Add(subValues);
                        subValues.AddRange(
                            Enumerable.Cast<object>(
                                (IEnumerable)prop.GetValue(item, null)));
                    } else {
                        // We have a list or array of a complex type
                        List<object> subKeys = new List<object>();
                        if (i == 0)
                            keys.Add(subKeys);
                        List<object> subValues = new List<object>();
                        itemValues.Add(subValues);
                        SplitKeyValues(
                            (IList)prop.GetValue(item, null), subKeys, subValues);
                    }
                } else if (prop.PropertyType.IsValueType ||
                           prop.PropertyType == typeof(string)) {
                    // We have a simple type
                    if (i == 0)
                        keys.Add(prop.Name);
                    itemValues.Add(prop.GetValue(item, null));
                } else {
                    // We have a complex type.
                    // Does not occur in your example
                }
            }
        }
    }
