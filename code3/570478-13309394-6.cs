    public static List<string> FromXml(string filename)
    {
        return XDocument.Load(filename)
                        .Root.Elements("Type")
                        .Select(x => x.Value)
                        .ToList();
    }
