    public static IDictionary<TKey, T> ToDictionary<TKey, T>(this DataTable table, Func<DataRow,TKey> getKey) where T : new()
    {
        IList<PropertyInfo> properties = GetPropertiesForType<T>();
        IDictionary<TKey, T> result = new Dictionary<TKey, T>();
        Dictionary<string, int> propDict = GetPropertyDictionary(properties, table);
        foreach (var row in table.Rows)
        {
            var item = CreateItemFromRow<T>((DataRow)row, properties, propDict);
            TKey pk = getKey((DataRow)row);
            result.Add(pk,item);
        }
        return result;
    }
