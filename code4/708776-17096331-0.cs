    public static IDictionary<string, int> GetLookupTable(string xmlContents)
    {
        return XElement.Parse(xmlContents)
                       .Elements()
                       .ToDictionary(x => x.Name.LocalName,
                                     x => (int) x);
    }
