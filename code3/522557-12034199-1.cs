    public static object DeSerializeFromXmlString(System.Type typeToDeserialize, string xmlString) 
    {
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(xmlString);
        MemoryStream memoryStream = new MemoryStream(bytes);
        System.Xml.Serialization.XmlSerializer xmlSerializer = 
            new System.Xml.Serialization.XmlSerializer(typeToDeserialize);
        return xmlSerializer.Deserialize(memoryStream);
    }
