    private static readonly XNamespace xn = "somenamespace";
    public bool ParseXDocument(string xml)
    {
        XDocument document = XDocument.Parse(xml);
        var obj = document.Root.Element(xn + "object");
        if (obj == null)
            return false;
        
        Attribute1 = (string)obj.Attribute("attribute1");
        Attribute2 = (string)obj.Attribute("attribute2");
        Element1 = (string)obj.Element(xn + "element1");
        Element2 = (string)obj.Elements(xn + "element1").ElementAtOrDefault(1);
        // ...
        return Validate();
    }
