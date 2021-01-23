    public static IEnumerable<T> Deserialize<T>(string listData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using (MemoryStream m = new MemoryStream(Convert.FromBase64String(listData)))
        {
            return (IEnumerable<T>)formatter.Deserialize(m);
        }
    }
