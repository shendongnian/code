    using System.Collections.Generic;
    using System.Linq;
    namespace MyProject.Util
    {
    public class LruCache<Key, Value>
    {
        public delegate Value ValueCreator();
        Dictionary<Key, ValueWithReference> cache;
        //The maximum number of elements that can fit in the cache.
        int maxCacheSize;
        IEnumerator<Value> valueRemover;
        public LruCache(int maxCacheSize) {
            this.cache = new Dictionary<Key, ValueWithReference>();
            this.maxCacheSize = maxCacheSize;
            this.valueRemover = GetKeyValuePairRemover().GetEnumerator();
        }
        /// <summary>
        /// Gets the value associated with the specified key. If it doesn't exist in the cache 
        /// then it will be created with createValue() and added to the cache. 
        /// </summary>
        public Value GetAndAddValue(Key key, ValueCreator createValue) {
            if (this.cache.ContainsKey(key) == false)
            {
                while (this.cache.Count >= this.maxCacheSize) {
                    this.valueRemover.MoveNext();
                }
                this.cache[key] = new ValueWithReference(createValue());
            }
            this.cache[key].recentlyUsed = true;
            return this.cache[key].value;
        }
        protected IEnumerable<Value> GetKeyValuePairRemover() { 
            while (true) {
                List<Key> keyList = this.cache.Keys.ToList();
                
                foreach(Key key in keyList) {
                    if (this.cache[key].recentlyUsed)
                    {
                        this.cache[key].recentlyUsed = false;
                    }
                    else {
                        Value removedValue = this.cache[key].value;
                        this.cache.Remove(key);
                        yield return removedValue;
                    }
                }
            }
        }
        protected class ValueWithReference
        {
            public Value value;
            public bool recentlyUsed;
            public ValueWithReference(Value value)
            {
                this.value = value;
                this.recentlyUsed = true;
            }
        }
    }
    }
