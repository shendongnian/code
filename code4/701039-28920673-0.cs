    public static IEnumerable<string> GetDescriptions<T>()
    {
        var attributes = typeof(T).GetMembers()
            .SelectMany(member => member.GetCustomAttributes(typeof (DescriptionAttribute), true).Cast<DescriptionAttribute>())
            .ToList();
    
        return attributes.Select(x => x.Description);
    }
