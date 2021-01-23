    private static Dictionary<string, HashSet<object>> getDistinctValues<T>(List<T> list)
    {
        var properties = typeof(T).GetProperties();
        //key is property name, value is a HashSet of distinct values for that property
        var results = properties
            .ToDictionary(prop => prop.Name, prop => new HashSet<object>());
    
        foreach (var item in list)
        {
            foreach (var prop in properties)
            {
                results[prop.Name].Add(prop.GetValue(item, null));
            }
        }
    
        return results;
    }
