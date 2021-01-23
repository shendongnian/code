    public abstract class Base<TSelf, TKey, TValue>
    {
        private static readonly IDictionary<TKey, Base<TSelf, TKey, TValue>> Values = 
            new Dictionary<TKey, Base<TKey, TValue>>();
        public TKey Key { get; private set; }
        public TValue Value { get; private set; }
        protected Base(TKey key, TValue value)
        {
            this.Key = key;
            this.Value = value;
            Values.Add(key, this);
        }
    }
    public sealed class One : Base<One, string, string>
    {
        public static readonly One Default = new One("DEF", "Default value");
        public static readonly One Invalid = new One("", "Invalid value");
        private One(string key, string value) : base(key, value) { }
    }
    public sealed class Two : Base<Two, string, string>
    {
        public static readonly Two EU = new Two("EU", "European Union");
        public static readonly Two USA = new Two("", "United States of America");
        private Two(string key, string value) : base(key, value) { }
    }
