    [Serializable]
    public struct KeyValuePairSerializable<K, V>
    {
        public KeyValuePairSerializable(KeyValuePair<K, V> pair)
        {
            Key = pair.Key;
            Value = pair.Value;
        }
    
        [XmlAttribute]
        public K Key { get; set; }
    
        [XmlText]
        public V Value { get; set; }
    
        public override string ToString()
        {
            return "[" + StringHelper.ToString(Key, "") + ", " + StringHelper.ToString(Value, "") + "]";
        }
    }
