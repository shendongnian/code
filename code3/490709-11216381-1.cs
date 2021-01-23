    public static T DeSerializeFromXml<T>(string pathToXML)
    {
        T db;
    
        using (XmlTextReader reader = new XmlTextReader(pathToXML))
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            db = (T)ser.Deserialize(reader);
        }
        return db;
    }
