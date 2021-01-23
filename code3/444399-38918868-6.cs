        private List<TValue> _pendingRemoval = new List<TValue>();
        public void RemoveLater(TValue item)
        {
            lock (_lock)
            {
                if (!_pendingRemoval.Contains(item))
                    _pendingRemoval.Add(item);
            }
        }
        public int Flush()
        {
            lock (_lock)
            {
                int count = _storage.RemoveAll(x => _pendingRemoval.Contains(x));
                _pendingRemoval.Clear();
                return count;
            }
        }
