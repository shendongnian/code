    public class ConflatedConcurrentQueue<TKey, TValue>
    {
        private readonly ConcurrentDictionary<TKey, Entry> entries;
        private readonly BlockingCollection<Entry> queue;
        public ConflatedConcurrentQueue()
        {
            this.entries = new ConcurrentDictionary<TKey, Entry>();
            this.queue = new BlockingCollection<Entry>();
        }
        public void Enqueue(TValue value, Func<TValue, TKey> keySelector)
        {
            // Get the entry for the key. Create a new one if necessary.
            Entry entry = entries.GetOrAdd(keySelector(value), delegate
            {
                return new Entry();
            });
            // Get exclusive access to the entry.
            lock (entry)
            {
                // Replace any old value with the new one.
                entry.Value = value;
                // Add the entry to the queue if it's not enqueued yet.
                if (!entry.Enqueued)
                {
                    entry.Enqueued = true;
                    queue.Add(entry);
                }
            }
        }
        public bool TryDequeue(out TValue value, TimeSpan timeout)
        {
            Entry entry;
            // Try to dequeue an entry (with timeout).
            if (!queue.TryTake(out entry, timeout))
            {
                value = default(TValue);
                return false;
            }
            // Get exclusive access to the entry.
            lock (entry)
            {
                // Mark it as dequeued
                entry.Enqueued = false;
                // Return the value
                value = entry.Value;
                return true;
            }
        }
        private class Entry
        {
            public TValue Value { get; set; }
            public bool Enqueued { get; set; }
        }
    }
