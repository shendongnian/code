    // create the root element, with the 'PanelControls' namespace
    XNamespace nSpace = "PanelControls";
    XElement element = new XElement("root",
              new XAttribute(XNamespace.Xmlns + "PanelControls", nSpace));
    element.Add(addXElement("FrequencyButtonA", nSpace ));
    ...
    private static XElement addXElement(string n, XNamespace ns)
    {
        return new XElement(ns + n,
            new XAttribute("Frequency", 113.123),
            new XAttribute("Width", 250));
    }
