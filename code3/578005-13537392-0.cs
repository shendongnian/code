    private static object Deserialize(string xml)
    {
        object toReturn = null;
        using (Stream stream = new MemoryStream())
        {
            byte[] data = System.Text.Encoding.UTF8.GetBytes(xml);
            stream.Write(data, 0, data.Length);
            stream.Position = 0;
            var netDataContractSerializer = new NetDataContractSerializer();
            toReturn = netDataContractSerializer.Deserialize(stream);
        }
        return toReturn;
    }
    private static string Serialize(object obj)
    {
        using (var memoryStream = new MemoryStream())
        using (var reader = new StreamReader(memoryStream))
        {
            var netDataContractSerializer = new NetDataContractSerializer();
            netDataContractSerializer.Serialize(memoryStream, obj);
            memoryStream.Position = 0;
            return reader.ReadToEnd();
        }
    }
