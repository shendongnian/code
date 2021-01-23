    public static T DeserializeObject<T>(byte[] bytes)
    {
        if (bytes== null)
            throw new ArgumentNullException("bytes");
        if (bytes.Length.Equals(0))
            throw new ArgumentException("bytes");
        T deserializedObject;
        using (MemoryStream memoryStream = new MemoryStream(bytes))
        {
            BinaryFormatter deserializer = new BinaryFormatter();
            deserializedObject = (T)deserializer.Deserialize(memoryStream);
        }
        return deserializedObject;
    }
    public static byte[] SerializeObject(object objToSerialize)
    {
        if (objToSerialize== null)
            throw new ArgumentNullException("objToSerialize");
        byte[] serializedObject;
        using (MemoryStream stream = new MemoryStream())
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, objToSerialize);
            serializedObject = stream.ToArray();
        }
        return serializedObject;
    }
