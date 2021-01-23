    private T Deserialize<T>(string xml, Type[] knownTypes)
    {
        var rootType = knownTypes.FirstOrDefault(t => t.GetCustomAttributes<XmlRootAttribute>()
                                                       .Any(a => a.ElementName == XElement.Parse(xml).Name.LocalName));
                               
        return (T)new XmlSerializer(rootType ?? typeof(T), knownTypes).Deserialize(new StringReader(xml));
    }
