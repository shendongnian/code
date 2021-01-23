    public class CustomDictionary<TValue> : Dictionary<string, TValue>, IXmlSerializable
    {
        private static readonly XmlSerializer ValueSerializer = new XmlSerializer(typeof(TValue));
        private readonly string _namespace;
        public CustomDictionary()
            : this("")
        {
        }
        public CustomDictionary(string @namespace)
        {
            _namespace = @namespace;
        }
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    var textReader = new StringReader(reader.Value);
                    this[reader.Name] = (TValue) ValueSerializer.Deserialize(textReader);
                }
            }
        }
        public void WriteXml(XmlWriter writer)
        {
            foreach(var kvp in this)
            {
                var document = new XDocument();
                
                using(var stringWriter = document.CreateWriter())
                {
                    ValueSerializer.Serialize(stringWriter, kvp.Value);
                }
                var serializedValue = document.Root.Value;
                writer.WriteElementString(kvp.Key, _namespace, serializedValue);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new CustomDictionary<string>
            {
                {"Hello", "World"},
                {"Hi", "There"}
            };
            var serializer = new XmlSerializer(typeof (CustomDictionary<string>));
            serializer.Serialize(Console.Out, dict);
            Console.ReadLine();
        }
    }
