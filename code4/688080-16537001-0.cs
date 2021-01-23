    public void ProcessXml(string XmlFileAddress)
    {
        XDocument doc = XDocument.Load(XmlFileAddress);
            
        ReadXElement(doc.Root);
    }
    private void ReadXElement(XElement xElement)
    {
        foreach (var attribute in xElement.Attributes())
        {
            Console.WriteLine(attribute.Name + " - " + attribute.Value);
        }
        foreach (var childElement in xElement.Elements())
        {
            ReadXElement(childElement);
        }
    }
