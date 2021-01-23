    public static IEnumerable<NameClass> GetNames(IEnumerable<NameClass> names, String name, int minCount)
    {
        var matchingNames = names.Where(n => n.Name.StartsWith(name));
        if (matchingNames.Count() >= minCount)
        {
            return matchingNames.ToList();
        }
        else
        {
            return null;
        }
    }
    var jones = GetNames(names, "Jones", 3);  
