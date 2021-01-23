    class LimitedSizeDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
     Dictionary<TKey, TValue> dict;
     Queue<TKey> queue;
     int size;
    
     public LimitedSizeDictionary(int size)
     {
     this.size = size;
     dict = new Dictionary<TKey, TValue>(size + 1);
     queue = new Queue<TKey>(size);
     }
    
     public void Add(TKey key, TValue value)
     {
     dict.Add(key, value);
     if (queue.Count == size)
     dict.Remove(queue.Dequeue());
     queue.Enqueue(key);
     }
    
     public bool Remove(TKey key)
     {
     if (dict.Remove(key))
     {
     Queue<TKey> newQueue = new Queue<TKey>(size);
     foreach (TKey item in queue)
     if (!dict.Comparer.Equals(item, key))
     newQueue.Enqueue(item);
     queue = newQueue;
     return true;
     }
     else
     return false;
     }
    }
