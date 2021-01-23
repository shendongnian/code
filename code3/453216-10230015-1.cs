    public void SerializeObject<T>(string filename, T obj)
       {
          Stream stream = File.Open(filename, FileMode.Create);
          BinaryFormatter binaryFormatter = new BinaryFormatter();
          binaryFormatter.Serialize(stream, obj);
          stream.Close();
       }
    
       public T DeSerializeObject<T> (string filename)
       {
          T objectToBeDeSerialized;
          Stream stream = File.Open(filename, FileMode.Open);
          BinaryFormatter binaryFormatter = new BinaryFormatter();
          objectToBeDeSerialized= (T)binaryFormatter.Deserialize(stream);
          stream.Close();
          return objectToBeDeSerialized;
       }
    
    [Serializable]
    struct MyStruct
    {
        byte[] ByteData;
        int MyInt;
        double MyDouble;
    }
