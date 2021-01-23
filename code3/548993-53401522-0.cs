    public interface IStrongIdentifier
        {
            string StringValue { get; set; }
        }
    public class StrongIdentifierKeyedDictionaryWrapper<TKey, TValue> : Dictionary<string, TValue>
            where TKey : IStrongIdentifier
        {
            public void Add(TKey key, TValue value)
            {
                base.Add(key.StringValue, value);
            }
    
            public void Remove(TKey key)
            {
                base.Remove(key.StringValue);
            }
            
            public TValue this[TKey index]
            {
                get => base[index.StringValue];
                set => base[index.StringValue] = value;
            }
    
            public bool ContainsKey(TKey key)
            {
                return base.ContainsKey(key.StringValue);
            }
        }
