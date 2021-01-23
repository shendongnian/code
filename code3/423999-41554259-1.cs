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
        using(var stringWriter = new StringWriter(Encoding.UTF8)) 
        {
            using(var xmlWriter = XmlWriter.Create(stringWriter, settings)) 
            {
                serializer.Serialize(xmlWriter, value);
            }
            return stringWriter.ToString();
        }
    }
