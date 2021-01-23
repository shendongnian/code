    public static IEnumerable<string> GetNames(this IEnumerable<string> list, 
        string prefix)
    {
        return list
            .Where(item => 
            list.Count(temp => item.Name!=prefix && item.Name.StartsWith(prefix)) >= 3)
            .Select(item  => item.Name);
    }
