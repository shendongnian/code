    public static bool AreEqual<T>(this IEnumerable<T> first, IEnumerable<T> second)
    {
        var dictionary = first.GroupBy(x => x)
            .ToDictionary(group => group.Key,
            group => group.Count());
    
        foreach (var item in second)
        {
            int count = dictionary[item];
            if (count <= 0)
                return false;
            else dictionary[item] = count - 1;
        }
    
        return dictionary.Values.All(count => count > 0);
    }
