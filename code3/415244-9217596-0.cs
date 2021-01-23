    public static long GetSerializedSize(object root)
    {
        using (var memoryStream = new MemoryStream())
        {
            var binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(memoryStream, root);
            return memoryStream.Length;
        }
    }
