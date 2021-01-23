    public class NullTolerantDictionary<TKey, TValue> 
             : Dictionary<TKey, TValue> where TValue : class
    {
        public static TValue MissingValue { get; private set; }
    }
