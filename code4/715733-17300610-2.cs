    public static string XmlSerialize<T>(T objectToSerialize)
    {
        XmlSerializer s = new XmlSerializer(typeof(T));
        
        var settings = new XmlWriterSettings
                           {
                               NewLineHandling = NewLineHandling.Entitize
                           };
        
        using(var stream = new StringWriter())
        using(var writer = XmlWriter.Create(stream, settings))
        {
            s.Serialize(writer, objectToSerialize);
            
            return stream.ToString();
        }
    }
    
    public static T XmlDeserialize<T>(string serializedObject)
    {
        XmlSerializer s = new XmlSerializer(typeof(T));
        
        using(var stream = new StringReader(serializedObject))
        using(var reader = XmlReader.Create(stream))
        {
            return (T)s.Deserialize(reader);
        }
    }
