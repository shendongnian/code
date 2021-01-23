    public static void Write<T>(T data)
    {
        DataContractSerializer dcs = new DataContractSerializer(typeof(T));
        using (MemoryStream stream = new MemoryStream())
        {
            dcs.WriteObject(stream, data);
        }
    }
    public static void Write(object data)
    {
        if (data == null)
            throw new ArgumentNullException();
        DataContractSerializer dcs = new DataContractSerializer(data.GetType());
        using (MemoryStream stream = new MemoryStream())
        {
            dcs.WriteObject(stream, data);
        }
    }
