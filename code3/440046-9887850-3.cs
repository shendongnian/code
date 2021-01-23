    using (FileStream fileStream = new FileStream("test.binary", FileMode.Open))
    {
        IFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        dict = (SerializableDictionary<String, Object>)bf.Deserialize(fileStream);
    }
