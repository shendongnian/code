    public static string SerializeToXmlString(object objectToSerialize) 
    {
        MemoryStream memoryStream = new MemoryStream();
        System.Xml.Serialization.XmlSerializer xmlSerializer = 
            new System.Xml.Serialization.XmlSerializer(objectToSerialize.GetType());
        xmlSerializer.Serialize(memoryStream, objectToSerialize);
        ASCIIEncoding ascii = new ASCIIEncoding();
        return ascii.GetString(memoryStream.ToArray());
    }
