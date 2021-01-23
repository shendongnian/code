    [XmlRoot(Namespace = "")]
    public class ObjectData
    {
        [XmlElement(Namespace = "")]
        public string ModelName { get; set; }
        [XmlElement(Namespace = "")]
        public string ObjectName { get; set; }
        [XmlArray("Values")]
        [XmlArrayItem("KeyValuePair")] 
        public List<KeyValuePair<string, string>> Values { get; set; }
    }
    [Serializable]
    public class KeyValuePair<K, V> {
        public K Key { get; set; }
        public V Value { get; set; }
        public KeyValuePair() { }
        public KeyValuePair(K key, V value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
