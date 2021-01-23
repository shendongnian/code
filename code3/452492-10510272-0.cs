If your JSON is a serialised representation of a .NET class, maybe you could use the DataContractJsonSerializer to deserialise it on the server, or perhaps you could just define a stub class for your JSON object if you don't need a generic solution to handle multiple datasets:
    string json = "{\"Test\": \"This is the content\"}";
    DataContractJsonSerializer ds = new DataContractJsonSerializer(typeof(TestJson));
    var deserialisedContent = ds.ReadObject(new MemoryStream(Encoding.ASCII.GetBytes(json)));
    foreach (var field in typeof (TestJson).GetFields())
    {
        Console.WriteLine("{0}:{1}", field.Name, field.GetValue(deserialisedContent));
    }
    ...
    [DataContract]
    private class TestJson
    {
        [DataMember]
        public string Test;
    }
