    void Main()
    {
        // get the xml value somehow
        var xdoc= XDocument.Parse(@"<Class><Property>Value</Property></Class>");
        
        // deserialize the xml into the proxy type
        var proxy = Deserialize<ClassSerializerProxy>(xdoc);
        
        // read the resulting value
        var value = proxy.ClassValue;
    }
    
    public object Deserialize(XDocument xmlDocument, Type DeserializeToType)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(DeserializeToType);
        using (XmlReader reader = xmlDocument.CreateReader())
            return xmlSerializer.Deserialize(reader);
    }
