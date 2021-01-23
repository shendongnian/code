    SerializableDictionary dict = new SerializableDictionary(otherDictionary);
    using (FileStream fileStream = new FileStream("test.binary", FileMode.Create))
    {
        IFormatter bf = new BinaryFormatter();
        bf.Serialize(fileStream, dict);
    }
    using (FileStream fileStream = new FileStream("test.binary", FileMode.Open))
    {
        IFormatter bf = new BinaryFormatter();
        myClass = (SerializableDictionary)bf.Deserialize(fileStream);
    }
