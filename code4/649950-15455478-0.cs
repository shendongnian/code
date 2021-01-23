    public static IEnumerable<string> getAspxNames()
    {
        var pageTypes = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.BaseType == typeof(Page));
        return pageTypes.Select(t => t.Name).ToList();
    }
    // ...
    foreach(string pageName in getAspxNames())
        dropdownlist1.Items.Add(pageName + ".aspx");
