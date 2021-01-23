    public class CustomDictionary<TValue> : Dictionary<string, TValue>, IXmlSerializable
    {
        private static readonly XmlSerializer ValueSerializer;
        private readonly string _namespace;
        static CustomDictionary()
        {
            ValueSerializer = new XmlSerializer(typeof(TValue));
            ValueSerializer.UnknownNode += ValueSerializerOnUnknownElement;
        }
        private static void ValueSerializerOnUnknownElement(object sender, XmlNodeEventArgs xmlNodeEventArgs)
        {
            Debugger.Break();
        }
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
            reader.Read();
            var keepGoing = true;
            while(keepGoing)
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    this[reader.Name] = (TValue) reader.ReadElementContentAs(typeof (TValue), null);
                }
                else
                {
                    keepGoing = reader.Read();
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
