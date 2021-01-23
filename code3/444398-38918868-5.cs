        public void RemoveAll(Predicate<TValue> predicate)
        {
            lock (_lock)
            {
                return _storage.RemoveAll(predicate);
            }
        }
