    public static T Deserialize<T>(string xml) where T : class, new()
    {
        if (string.IsNullOrEmpty(xml))
        {
            throw new ArgumentNullException("xml");
        }
    
        return (T)Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xml)));
    }
    
    public static T Deserialize<T>(Stream xmlStream) where T : class, new()
    {
        if (xmlStream == null)
        {
            throw new ArgumentNullException("xmlStream");
        }
    
        return (T)xmlSerializer.Deserialize(xmlStream);
    }
