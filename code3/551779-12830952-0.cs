    private static IEnumerable<XElement> FindElements(string filename, string name)
    {
        XElement x = XElement.Load(filename);
        return x.Descendants()
                .Where(e => e.Name.ToString().Equals(name) ||
                            e.Value.Equals(name) ||
                            e.Attributes().Any(a => a.Name.ToString().Equals(name) || 
                                                    a.Value.Equals(name)));
    }
