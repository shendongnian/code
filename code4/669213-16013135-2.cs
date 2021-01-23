    public object Deserialize(System.Type expectedDataType)
    {
        object data = null;
        System.Xml.Serialization.XmlSerializer deserializer =
            new System.Xml.SerializationXmlSerializer(expectedDataType);
    
        System.XML.XmlReader reader = System.XML XmlReader.Create(this.MyStream);
    
        deserializer.Deserialize(reader, data);
        return data;
    }
