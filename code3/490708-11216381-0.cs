    public static T DeSerializeFromXml<T>(string pathToXML)
    {
        T db;
    
        using (XmlTextReader reader = new XmlTextReader(pathToXML))
        {
            XmlSerializer ser = new XmlSerializer(typeof(cDatabases));
            db = (T)ser.Deserialize(reader);
        }
        return db;
    }
