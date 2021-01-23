    public static T GetDataFromFile<T>(string path) 
    { 
        if (!File.Exists(path)) 
        { 
            return null; 
        } 
 
        try 
        { 
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(typeof(T)); 
            StreamReader tempReader = new StreamReader(path); 
            T result = (T)x.Deserialize(tempReader); 
            tempReader.Close(); 
            return result; 
        } 
        catch 
        { 
            return null; 
        } 
    } 
