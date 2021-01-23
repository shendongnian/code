    var serializer = new DataContractSerializer(facets.GetType());
    using (var stream = new MemoryStream())
    {
        serializer.WriteObject(stream, facets);
        string xml = Encoding.UTF8.GetString(stream.ToArray());
    }
