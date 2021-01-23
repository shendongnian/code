    T DeepCopy<T>(T instance)
    {
      BinaryFormatter formatter=new BinaryFormatter();
    
      using(var stream=new MemoryStream())
      {
        formatter.Serialize(stream, instance);
        stream.Position=0;
    
        return (T)formatter.Deserialize(stream);
      }
    }
