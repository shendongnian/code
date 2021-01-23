    public struct kvp
    {
        public string Key { get; private set; }
        public string Value { get; private set; }
        public kvp(string key, string value)
            : this()
        {
            Key = key;
            Value = value;
        }
        public static implicit operator KeyValuePair<string, string>(kvp k)
        {
            return new KeyValuePair<string, string>(k.Key, k.Value);
        }
        public static implicit operator kvp(KeyValuePair<string, string> k)
        {
            return new kvp(k.Key, k.Value);
        }
    }
