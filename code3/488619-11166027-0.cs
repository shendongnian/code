    class Program
        {
            static void Main(string[] args)
            {
                var mytypeTest = new MyType
                {
                    Name = "a",
                    MyTypes = new List<MyType>
                    {
                        new MyType
                        {
                            Name = "b"
                        }
                    }.ToArray()
                };
    
                var xml = mytypeTest.Serialize();
    
                var result = xml.Deserialize<MyType>();
            }
        }
    
        public class MyType
        {
            [XmlAttribute]
            public string Name { get; set; }
            [XmlElement(ElementName="MyType")]
            public MyType[] MyTypes { get; set; }
        }
    
        public static class XmlSerializerExtensions
        {
            public static T Deserialize<T>(this string xml) where T : new()
            {
                var _serializer = new XmlSerializer(typeof(T));
                using (var _stringReader = new StringReader(xml))
                {
                    using (XmlReader _reader = new XmlTextReader(_stringReader))
                    {
                        return (T)_serializer.Deserialize(_reader);
                    }
                }
            }
    
            public static string Serialize<T>(this T value) where T : new()
            {
                var _serializer = new XmlSerializer(typeof(T));
                using (var _stream = new MemoryStream())
                {
                    using (var _writer = new XmlTextWriter(_stream, new UTF8Encoding()))
                    {
                        _serializer.Serialize(_writer, value);
                        return Encoding.UTF8.GetString(_stream.ToArray());
                    }
                }
            }
        }
