    public static List<string> FromXml(string filename)
    {
        return XDocument.Parse(filename)
                        .Descendants("Type")
                        .Select(x => x.Value)
                        .ToList();
    }
