    public static string Serialize<T>(T instance)
    {
        var formatter = new BinaryFormatter();
        using (var stream = new MemoryStream())
        {
            formatter.Serialize(stream, instance);
            return Convert.ToBase64String(stream.ToArray());
        }
    }
    public static T Deserialize<T>(string serialized)
    {
        var formatter = new BinaryFormatter();
        using (var stream = new MemoryStream(Convert.FromBase64String(serialized)))
        {
            return (T)formatter.Deserialize(stream);
        }
    }
