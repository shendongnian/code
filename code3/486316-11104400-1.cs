    public abstract class Base<T, TKey, TValue> where T : Base<T, TKey, TValue>
    { 
        private static readonly IDictionary<TKey, T> Values = 
            new Dictionary<TKey, T>(); 
 
        public TKey Key { get; private set; } 
        public TValue Value { get; private set; } 
 
        protected Base(TKey key, TValue value) 
        { 
            this.Key = key; 
            this.Value = value; 
 
            Values.Add(key, this); 
        } 
    } 
