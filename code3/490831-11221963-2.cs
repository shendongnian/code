    static void Main()
    {
        var o = new Foo {
            Prop = new Dictionary<string,string> { {"foo","bar"} }
        };
        var ms = new MemoryStream();
        var slz = new DataContractSerializer(typeof(Foo));
        slz.WriteObject(ms, o,
            new Dictionary<string,string>
            {
                { "arr", "http://schemas.microsoft.com/2003/10/Serialization/Arrays" },
            });
        string data = Encoding.UTF8.GetString(ms.ToArray());
        Console.WriteLine(data);
    }
    public static class Extensions
    {
        public static void WriteObject(
            this DataContractSerializer serializer,
            Stream stream, object data,
            Dictionary<string,string> namespaces)
        {
            using (var writer = XmlWriter.Create(stream))
            {
                serializer.WriteStartObject(writer, data);
                foreach (var pair in namespaces)
                {
                    writer.WriteAttributeString("xmlns", pair.Key, null, pair.Value);
                }
                serializer.WriteObjectContent(writer, data);
                serializer.WriteEndObject(writer);
            }
        }
    }
    [DataContract]
    class Foo
    {
        [DataMember]
        public Dictionary<string,string> Prop;
    }
