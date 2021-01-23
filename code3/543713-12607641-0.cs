        public static dynamic GetDataFromFile(string path, Type convertType) 
        { 
            if (!File.Exists(path)) 
        { 
            return null; 
        } 
 
        try 
        { 
            CountriesInfo tempData = new CountriesInfo(); 
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer  (tempData.GetType()); 
            StreamReader tempReader = new StreamReader(path); 
            tempData = (CountriesInfo)x.Deserialize(tempReader); 
            tempReader.Close(); 
            return Convert.ChangeType(CountriesInfo, convertType);
        } 
        catch 
        { 
            return null; 
        } 
    } 
