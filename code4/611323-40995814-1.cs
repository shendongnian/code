    public T DeserializeXML<T>(string xmlContent)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(xmlContent));
        return (T)serializer.Deserialize(memStream);
    }
    ....
    string resultXml = resp.GetResponseStream();
    VINquery resultObject = DeserializeXML<VINquery>(resultObject); 
