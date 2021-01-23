    public static EntityCollection<T> ToEntityCollection<T>(this IEnumerable<T> source) 
    {
        var col = new EntityCollection<T>();
        foreach (var item in source)
        {
            col.Add(item);
        }
        return col;
    }
