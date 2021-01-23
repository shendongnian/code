    public class NonLockingCollection
    {
        private List<string> collection;
        public NonLockingCollection()
        {
            // Initialize global collection through a volatile write.
            Interlocked.CompareExchange(ref collection, new List<string>(), null);
        }
        public void AddString(string s)
        {
            while (true)
            {
                // Volatile read of global collection.
                var original = Interlocked.CompareExchange(ref collection, null, null);
                // Add new string to a local copy.
                var copy = original.ToList();
                copy.Add(s);
                // Swap local copy with global collection,
                // unless outraced by another thread.
                var result = Interlocked.CompareExchange(ref collection, copy, original);
                if (result == original)
                    break;
            }
        }
        public override string ToString()
        {
            // Volatile read of global collection.
            var original = Interlocked.CompareExchange(ref collection, null, null);
            // Since content of global collection will never be modified,
            // we may read it directly.
            return string.Join(",", original);
        }
    }
