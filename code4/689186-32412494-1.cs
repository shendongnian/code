    using System.Runtime.Serialization.Json;
    using (var stream = new MemoryStream(Encoding.ASCII.GetBytes(jsonOutput)))
    {
        var xml = XDocument.Load(JsonReaderWriterFactory.CreateJsonReader(stream, new XmlDictionaryReaderQuotas()));
    }
