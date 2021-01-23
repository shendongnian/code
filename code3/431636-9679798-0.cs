    var obj = new Foo
    {
        Timestamp = DateTime.Now
    };
    var xs = new XmlSerializer(obj.GetType());
    using (var stream = new MemoryStream())
    {
        xs.Serialize(stream, obj);
        string xml = Encoding.UTF8.GetString(stream.ToArray());
    }
