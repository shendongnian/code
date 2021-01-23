    private int[] ParseBusyPlace(string xml)
    {
        return XDocument.Parse(xml)
                        .Descendants("Place")
                        .Select(element => (int) element.Attribute("ID"))
                        .ToArray();
    }
