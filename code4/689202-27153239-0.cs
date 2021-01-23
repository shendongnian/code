    private static T Deserialize<T>(XmlNode data) where T : class, new()
    {
        if (data == null)
            return null;
    
        var ser = new XmlSerializer(typeof(T));
    
        using (var sr = new XmlNodeReader(data))
        {
            return (T)ser.Deserialize(sr);
        }
    }
