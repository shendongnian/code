    private static readonly XNamespace xn = "somenamespace";
        
    public void ParseXDocument(string xml)
    {
        XDocument document = XDocument.Parse(xml);
        var obj = document.Root.Element(xn + "object");
        if (obj != null)
        {
            Attribute1 = (string)obj.Attribute("attribute1");
            Attribute2 = (string)obj.Attribute("attribute2");
            // ...
        }
    }
