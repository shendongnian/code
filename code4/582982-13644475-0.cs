    public static T Clone<T>(T source)
    {
        DataContractSerializer serializer = new DataContractSerializer(typeof(T));
        using (MemoryStream ms = new MemoryStream())
        {
            serializer.WriteObject(ms, source);
            ms.Seek(0, SeekOrigin.Begin);
            return (T)serializer.ReadObject(ms);
        }
    } 
