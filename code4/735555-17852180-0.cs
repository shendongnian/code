    public class MultipleDictionary<TKey, TValue>
    {
        private IDictionary<TKey, IList<TValue>> _dict;
        public bool ContainsKey(TKey key)
        {
            return _dict.ContainsKey(key);
        }
        public TValue this[TKey key]
        {
            get 
            {
                if (_dict.ContainsKey(key))
                    return _dict[key][0];
                return default(TValue);
            }
            set
            {
                if (_dict.ContainsKey(key))
                {
                    IList<TValue> valList = _dict[key];
                    valList.Add(value);
                }
                else
                {
                    IList<TValue> list = new List<TValue>();
                    list.Add(value);
                    _dict.Add(key, list);
                }
            }
        }
    }
