    public class NonLockingCollection
    {
        private List<string> collection;
        public NonLockingCollection()
        {
            // Initialize global collection through a volatile write.
            collection = new List<string>();
            Thread.MemoryBarrier();
        }
        public void AddString(string s)
        {
            while (true)
            {
                // Fresh volatile read of global collection.
                Thread.MemoryBarrier();
                var original = collection;
                Thread.MemoryBarrier();
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
            // Fresh volatile read of global collection.
            Thread.MemoryBarrier();
            var original = collection;
            Thread.MemoryBarrier();
            // Since content of global collection will never be modified,
            // we may read it directly.
            return string.Join(",", original);
        }
    }
