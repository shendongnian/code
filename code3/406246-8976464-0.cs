    public static T DeepCopy(T oldclass)
    {
        using (MemoryStream stream = new MemoryStream())
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, oldclass);
            ms.Position = 0;
            return (T)formatter.Deserialize(stream);
        }
    }
