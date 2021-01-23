    public static IEnumerable<Type> getCommonTypes(IEnumerable source)
    {
        HashSet<Type> types = new HashSet<Type>();
        foreach (object item in source)
        {
            types.Add(item.GetType());
        }
    
        return types.Select(t => getBaseTypes(t))
            .Aggregate((a, b) => a.Intersect(b));
    }
