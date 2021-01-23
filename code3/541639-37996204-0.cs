    public class DictionarySerializer<TKey, TValue>
    {
        [XmlType(TypeName = "Item")]
        public class Item
        {
            [XmlAttribute("key")]
            public TKey Key;
            [XmlAttribute("value")]
            public TValue Value;
        }
        private XmlSerializer _serializer = new XmlSerializer(typeof(Item[]), new XmlRootAttribute("Dictionary"));
        public Dictionary<TKey, TValue> Deserialize(string filename)
        {
            using (FileStream stream = new FileStream(filename, FileMode.Open))
            using (XmlReader reader = XmlReader.Create(stream))
            {
                return ((Item[])_serializer.Deserialize(reader)).ToDictionary(p => p.Key, p => p.Value);
            }
        }
        public void Serialize(string filename, Dictionary<TKey, TValue> dictionary)
        {
            using (var writer = new StreamWriter(filename))
            {
                _serializer.Serialize(writer, dictionary.Select(p => new Item() { Key = p.Key, Value = p.Value }).ToArray());
            }
        }
    }
