        public static string Serialize<T>(object item)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, item);
            return writer.ToString();
        }
        public static T DeSerialize<T>(string input) where T : class
        {
            StringReader reader = new StringReader(input);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            return serializer.Deserialize(reader) as T;
        }
