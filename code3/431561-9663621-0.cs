    public string SerializeToXml<T>(T obj)
    {
        using (var stream = new MemoryStream())
        {
            var xs = new XmlSerializer(typeof(T));
            xs.Serialize(stream, obj);
            return Encoding.UTF8.GetString(stream.ToArray());
        }
    }
