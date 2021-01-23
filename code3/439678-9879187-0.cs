    public static IEnumerable<NameClass> GetNames(IEnumerable<NameClass> names, String name, int minCount)
    {
        var matchingNames = names.Where(n => n.Name.StartsWith(name)).Take(minCount);
        if (matchingNames.Count() == minCount)
        {
            return matchingNames;
        }
        else {
            return null;
        }
    }
    var jones = GetNames(names, "Jones", 3);  
