    public static T Copy<T>(this T obj)
        where T : class
    {
        using (MemoryStream stream = new MemoryStream())
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj);
    
            stream.Seek(0, SeekOrigin.Begin);
            return formatter.Deserialize(stream) as T;
        }
    }
