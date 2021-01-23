        public static string Serialize(IDictionary dictionary)
        {
            using (StringWriter writer = new StringWriter())
            {
                Serialize(writer, dictionary);
                return writer.ToString();
            }
        }
        public static void Serialize(TextWriter writer, IDictionary dictionary)
        {
            if (writer == null)
                throw new ArgumentNullException("writer");
            using (XmlTextWriter xwriter = new XmlTextWriter(writer))
            {
                Serialize(xwriter, dictionary);
            }
        }
        public static void Serialize(XmlWriter writer, IDictionary dictionary)
        {
            if (writer == null)
                throw new ArgumentNullException("writer");
            if (dictionary == null)
                throw new ArgumentNullException("dictionary");
            foreach (DictionaryEntry entry in dictionary)
            {
                writer.WriteStartElement(string.Format("{0}", entry.Key));
                writer.WriteValue(entry.Value);
                writer.WriteEndElement();
            }
        }
