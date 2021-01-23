    DataClass dataClass = new DataClass("name", "descr");
    dataClass.Dictionary.Add("key1", new HashSet<DataClass>() { new DataClass("sample11", "descr11"), new DataClass("sample12", "descr12") });
    dataClass.Dictionary.Add("key2", new HashSet<DataClass>() { new DataClass("sample21", "descr21"), new DataClass("sample22", "descr22") });
    dataClass.Dictionary.Add("key3", new HashSet<DataClass>() { new DataClass("sample31", "descr31"), new DataClass("sample32", "descr32") });
                
    byte[] serialized;
    var formatter = new BinaryFormatter();
    
    using (MemoryStream stream = new MemoryStream())
    {
        formatter.Serialize(stream, dataClass);
        serialized = stream.ToArray();
    }
    using (MemoryStream streamDeserial = new MemoryStream())
    {
        streamDeserial.Write(serialized, 0, serialized.Length);
        streamDeserial.Seek(0, SeekOrigin.Begin);
        var dictDeserial = formatter.Deserialize(streamDeserial) as DataClass;
    } 
