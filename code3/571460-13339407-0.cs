    private static XmlAttributeOverrides SerializationOverrides()
    {
        var overrides = new XmlAttributeOverrides();
    
        overrides.Add(typeof(Model.ISession), XmlInclude("Session", typeof(Model.Session)));
    
        return overrides;
    }
    
    private static XmlAttributes XmlInclude(string name, Type type)
    {
        var attrs = new XmlAttributes();
        attrs.XmlElements.Add(new XmlElementAttribute(name, type));
        return attrs;
    }
