    public class TwoWayDictionary<TKey, TValue>
    {
        readonly IDictionary<TKey, TValue> dict;
        readonly Func<TKey, TValue> GetValueWhereKey;
        readonly Func<TValue, TKey> GetKeyWhereValue;
        readonly bool _mustValueBeUnique = true;
        public TwoWayDictionary()
        {
            this.dict = new Dictionary<TKey, TValue>();
            this.GetValueWhereKey = (strValue) => dict.Where(kvp => Object.Equals(kvp.Key, strValue)).Select(kvp => kvp.Value).FirstOrDefault();
            this.GetKeyWhereValue = (intValue) => dict.Where(kvp => Object.Equals(kvp.Value, intValue)).Select(kvp => kvp.Key).FirstOrDefault();
        }
        public TwoWayDictionary(KeyValuePair<TKey, TValue>[] kvps)
            : this()
        {
            this.AddRange(kvps);
        }
        public void AddRange(KeyValuePair<TKey, TValue>[] kvps)
        {
            kvps.ToList().ForEach( kvp => {        
                if (!_mustValueBeUnique || !this.dict.Any(item => Object.Equals(item.Value, kvp.Value)))
                {
                    dict.Add(kvp.Key, kvp.Value);
                } else {
                    throw new InvalidOperationException("Value must be unique");
                }
            });
        }
        public TValue this[TKey key]
        {
            get { return GetValueWhereKey(key); }
        }
        public TKey this[TValue value]
        {
            get { return GetKeyWhereValue(value); }
        }
    }
----
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new TwoWayDictionary<string, int>(new KeyValuePair<string, int>[] {
                new KeyValuePair<string, int>(".jpeg",100),
                new KeyValuePair<string, int>(".jpg",101),
                new KeyValuePair<string, int>(".txt",102),
                new KeyValuePair<string, int>(".zip",103)
            });
            var r1 = dict[100];
            var r2 = dict[".jpg"];
        }
    }
