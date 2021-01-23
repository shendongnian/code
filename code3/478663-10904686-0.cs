    public static IEnumerable<T> Deserialize<T>(string listData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using (MemoryStream m = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(listData)))
        {
            return (IEnumerable<T>)formatter.Deserialize(m);
        }
    }
