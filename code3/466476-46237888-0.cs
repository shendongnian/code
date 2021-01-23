    public class MutableKeyValuePair<KeyType, ValueType>
        {
            public KeyType Key { get; set; }
            public ValueType Value { get; set; }
    
            public MutableKeyValuePair() { }
    
            public MutableKeyValuePair(KeyType key, ValueType val)
            {
                Key = key;
                Value = val;
            }
        }
