    public class DictionarySerializer : IXmlSerializable
    {
        private Dictionary<string, object> _dictionary;
        private DictionarySerializer()
        {
            this._dictionary = new Dictionary<string,object>();
        }
        private DictionarySerializer(Dictionary<string, object> dictionary)
        {
            this._dictionary = dictionary;
        }
        public static void Serialize(StreamWriter stream, Dictionary<string, object> dictionary)
        {
            DictionarySerializer ds = new DictionarySerializer(dictionary);
            XmlSerializer xs = new XmlSerializer(typeof(DictionarySerializer));
            xs.Serialize(stream, ds);
        }
        public static void Serialize(Stream stream, Dictionary<string, object> dictionary)
        {
            DictionarySerializer ds = new DictionarySerializer(dictionary);
            XmlSerializer xs = new XmlSerializer(typeof(DictionarySerializer));
            xs.Serialize(stream, ds);
        }
        public static Dictionary<string, object> Deserialize(Stream stream)
        {
            XmlSerializer xs = new XmlSerializer(typeof(DictionarySerializer));
            DictionarySerializer ds = (DictionarySerializer)xs.Deserialize(stream);
            return ds._dictionary;
        }
        public static Dictionary<string, object> Deserialize(TextReader stream)
        {
            XmlSerializer xs = new XmlSerializer(typeof(DictionarySerializer));
            DictionarySerializer ds = (DictionarySerializer)xs.Deserialize(stream);
            return ds._dictionary;
        }
        XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }
        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            reader.Read();
            ReadFromXml(reader);
        }
        private void ReadFromXml(XmlReader reader)
        {
            reader.ReadStartElement("dictionary");
            while (reader.NodeType != XmlNodeType.EndElement)
            {
                reader.ReadStartElement("item");
                string key = reader.ReadElementString("key");
                reader.ReadStartElement("value");
                object value = null;
                if (reader.Name == string.Empty)
                {
                    value = reader.Value;
                    reader.Read();
                }
                else if (reader.Name == "dictionary")
                {
                    DictionarySerializer innerSerializer = new DictionarySerializer();
                    innerSerializer.ReadFromXml(reader);
                    value = innerSerializer._dictionary;
                }
                reader.ReadEndElement();
                reader.ReadEndElement();
                reader.MoveToContent();
                _dictionary.Add(key, value);
            }
            reader.ReadEndElement();
        }
        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("dictionary");
            foreach (string key in _dictionary.Keys)
            {
                object value = _dictionary[key];
                writer.WriteStartElement("item");
                writer.WriteElementString("key", key.ToString());
                if (value is Dictionary<string, object>)
                {
                    writer.WriteStartElement("value");
                    IXmlSerializable aSer = new DictionarySerializer((Dictionary<string, object>)value);
                    aSer.WriteXml(writer);
                    writer.WriteEndElement();
                }
                else
                    writer.WriteElementString("value", value.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
    }
