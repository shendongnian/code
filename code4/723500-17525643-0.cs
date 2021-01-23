    public class Xml
    {
        public static string Serialize<T>(T value) where T : class
        {
            if (value == null)
            {
                return string.Empty;
            }
            var xmlSerializer = new XmlSerializer(typeof(T));
            var stringWriter = new StringWriter();
            using (var xmlWriter = XmlWriter.Create(stringWriter))
            {
                xmlSerializer.Serialize(xmlWriter, value);
                return stringWriter.ToString();
            }
        }
        public static T Deserialize<T>(string xml)
        {
            var serializer = new XmlSerializer(typeof(T));
            T result;
            using (TextReader reader = new StringReader(xml))
            {
                result = (T) serializer.Deserialize(reader);
            }
            return result;
        }
    }
