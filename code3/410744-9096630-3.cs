    public static IEnumerable<XElement> WithName(this IEnumerable<XElement> elements,
                                                 string name)
    {
        this elements.Where(x => (string) x.Attribute("Name") == name);
    }
