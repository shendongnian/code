        public void RemoveAll(Predicate<TValue> predicate)
        {
            lock (_lock)
            {
                _storage.RemoveAll(predicate);
            }
        }
