    private static readonly XNamespace xn = "somenamespace";
        
    public static MyClass CreateFrom(XDocument document)
    {
        if (document == null)
            throw new ArgumentNullException("document");
        var obj = document.Root.Element(xn + "object");
        if (obj == null)
            throw new ArgumentException("Invalid XML structure");
        return new MyClass
        {
            Attribute1 = (string)obj.Attribute("attribute1");
            Attribute2 = (string)obj.Attribute("attribute2");
            Element1 = (string)obj.Element(xn + "element1");
            Element2 = (string)obj.Elements(xn + "element1").ElementAtOrDefault(1);
            // ...
        };
    }
