    public class DictionaryDifference<TKey, TValue>
    {
        public TKey Key
        {
            get;
            set;
        }
        public TValue OriginalValue
        {
            get;
            set;
        }
        public TValue NewValue
        {
            get;
            set;
        }
    }
