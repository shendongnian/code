        public static T DeserializeString<T>(String content)
        {
            using (TextReader reader = new StringReader(content))
            {
                XmlSerializer s = new XmlSerializer(typeof(T));
                return (T)s.Deserialize(reader);
            }
        }
