    public class MyDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        IDictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();
        //LOTS of other methods here, that are required by IDictionary<TKey, TValue>
        public TValue this[TKey key] //implementation of a interface
        {
            get
            {
                return dictionary[key];
            }
            set
            {
                dictionary[key] = value;
            }
        }
    }
