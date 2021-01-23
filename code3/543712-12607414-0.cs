    public static T GetDataFromFile<T>(string path) where T : class
    {
        if (!File.Exists(path))
        {
            return null;
        }
    
        try
        {
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(typeof(T));
            using(StreamReader tempReader = new StreamReader(path))
            {
                return (T)x.Deserialize(tempReader);
            }
        }
        catch
        {
            return null;
        }
    }
