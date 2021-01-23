    using System.Runtime.Serialization.Json;
    using (var stream = new MemoryStream(Encoding.ASCII.GetBytes(jsonOutput)))
    {
        var quotas = new XmlDictionaryReaderQuotas();
        var jsonReader = JsonReaderWriterFactory.CreateJsonReader(stream, quotas);
        var xml = XDocument.Load(jsonReader);
        Console.WriteLine(xml);
    }
