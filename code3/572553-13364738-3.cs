    public T SerialiseObject<T>(string json) where T : InterfaceA
    {
    var serializer = new DataContractJsonSerializer(T);
    
    var ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
     return (T)serializer.ReadObject(ms);
    }
