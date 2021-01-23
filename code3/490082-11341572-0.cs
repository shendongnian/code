    public static Dictionary<string, string> GetFieldsAndValuesOfCreatedItem(object item)
    {
        var propertyInfoList = item.GetType().GetProperties(BindingFlags.DeclaredOnly |
                                                                BindingFlags.Public |
                                                                BindingFlags.Instance);
        var list = new Dictionary<string, string>();
        foreach (var propertyInfo in propertyInfoList)
        {
            var valueObject = propertyInfo.GetValue(item, null);
            var value = valueObject != null ? valueObject.ToString() : string.Empty;
            if (!string.IsNullOrEmpty(value))
            {
                list.Add(propertyInfo.Name, value);
            }
        }
        return list;
    }
