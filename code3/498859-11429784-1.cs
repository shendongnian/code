    using  System.Xml;
    using  System.Xml.XPath;
    ...
    
    public foo()
    {
        XElement yourNode = XElement.Parse(yourstring);
        XElement college = root.XPathSelectElement("//College[Id='Oxford']");
    }
