        public class ConcurrentDictionaryWrapper<TKey,TValue> : IProducerConsumerCollection<KeyValuePair<TKey,TValue>>
    {
        private ConcurrentDictionary<TKey, TValue> dictionary;
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return dictionary.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }
        public int Count
        {
            get { return dictionary.Count; }
        }
        public object SyncRoot
        {
            get { return this; }
        }
        public bool IsSynchronized
        {
            get { return true; }
        }
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
        {
            throw new NotImplementedException();
        }
        public bool TryAdd(KeyValuePair<TKey, TValue> item)
        {
            return dictionary.TryAdd(item.Key, item.Value);
        }
        public bool TryTake(out KeyValuePair<TKey, TValue> item)
        {
            item = dictionary.FirstOrDefault();
            TValue value;
            return dictionary.TryRemove(item.Key, out value);
        }
        public KeyValuePair<TKey, TValue>[] ToArray()
        {
            throw new NotImplementedException();
        }
    }
