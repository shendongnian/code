    using (FileStream fileStream = new FileStream("test.binary", FileMode.Create))
    {
        IFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        bf.Serialize(fileStream, dict);
    }
