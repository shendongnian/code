    public static string SerializeObject<T>(this T value)
    {
        var serializer = new XmlSerializer(typeof(T));           
        var settings = new XmlWriterSettings
                       {
                        Encoding = new UTF8Encoding(true), 
                        Indent = false, 
                        OmitXmlDeclaration = false,
                        NewLineHandling = NewLineHandling.None
                       };
        
        using(var xmlWriter = XmlWriter.Create("MyFile.xml", settings)) 
        {
            serializer.Serialize(xmlWriter, value);
        }
        XmlDocument xml = new XmlDocument();
        xml.Load("MyFile.xml");
        byte[] bytes = Encoding.UTF8.GetBytes(xml.OuterXml);        
        File.Delete("MyFile.xml");
        return Encoding.UTF8.GetString(bytes);
        
    }
