    public class GenericKeyedCollection<TKey, TValue> : KeyedCollection<TKey, TValue> {
        private readonly Func<TValue, TKey> _keyGenerator;
        public GenericKeyedCollection(Func<TValue, TKey> keyGenerator) {
            _keyGenerator = keyGenerator;
        }
    
        protected override int GetKeyForItem(TValue item)
       {
          return _keyGenerator(item);
       }
    }
