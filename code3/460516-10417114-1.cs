    private static Dictionary<string, Dictionary<object, int>> 
        getDistinctValues<T>(List<T> list)
    {
        var properties = typeof(T).GetProperties();
    
        var result = properties
            //The key of the first dictionary is the property name
            .ToDictionary(prop => prop.Name,
                //the value is another dictionary
                prop => list.GroupBy(item => prop.GetValue(item, null))
                    //The key of the inner dictionary is the unique property value
                    //the value if the inner dictionary is the count of that group.
                    .ToDictionary(group => group.Key, group => group.Count()));
    
        return result;
    }
