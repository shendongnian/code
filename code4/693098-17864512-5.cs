    static void Main(string[] args)
    {
        var serializeMe = new Foo() { Id = new ComponentIdentifier() };
        var xml = Serialize(serializeMe);
        Console.WriteLine(xml);
        Console.ReadKey();
    }
    [DataContract]
    public class Foo
    {
        [DataMember]
        public ComponentIdentifier Id { get; set; }
    }
    [DataContract, JsonConverter(typeof(ComponentIdentifierJsonConverter))]
    public struct ComponentIdentifier
    {
        [DataMember]
        private long identifier;
        public class ComponentIdentifierJsonConverter : JsonConverter
        {
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                writer.WriteValue(((ComponentIdentifier)value).identifier.ToString());
            }
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                return new ComponentIdentifier() { identifier = int.Parse((string)JToken.ReadFrom(reader)) };
            }
            public override bool CanConvert(Type objectType)
            {
                if (objectType == typeof(ComponentIdentifier))
                    return true;
                return false;
            }
        }
    }
    public static string Serialize(object obj)
    {
        var json = JsonConvert.SerializeObject(obj);
        var xml = JsonConvert.DeserializeXNode(json);
        xml = new XDocument(
            new XDeclaration("1.0", "utf-8", "yes"),
            new XElement(obj.GetType().Name, xml.Root));
        return xml.ToString();
    }
