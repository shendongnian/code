        public ConcurrentList()
        {
        }
        public ConcurrentList(IEnumerable<TValue> other)
        {
            lock (_lock)
            {
                _storage = new List<TValue>(other);
            }
        }
