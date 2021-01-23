    Dictionary<String, Object> otherDictionary = new Dictionary<String, Object>();
    otherDictionary.Add("Foo", new List<String>() { "1st Foo","2nd Foo","3rd Foo" });
    var dict = new SerializableDictionary<String, Object>(otherDictionary);
    using (FileStream fileStream = new FileStream("test.binary", FileMode.Create))
    {
        IFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        bf.Serialize(fileStream, dict);
    }
    using (FileStream fileStream = new FileStream("test.binary", FileMode.Open))
    {
        IFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        dict = (SerializableDictionary<String, Object>)bf.Deserialize(fileStream);
    }
