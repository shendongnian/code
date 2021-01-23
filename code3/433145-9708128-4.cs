    public class ChangeTracker<T> where T : IEquatable<T>, ICloneable
    {
        //item "checkpoints" that are internal to this list
        private Dictionary<int, T> _originals = new Dictionary<int, T>();
        private Dictionary<T, int> _originalIndex = new Dictionary<T, int>();
        
        //the current, live-edited objects
        private Dictionary<int, T> _copies = new Dictionary<int, T>();
        private Dictionary<T, int> _copyIndex = new Dictionary<T, int>();
        public bool IsChanged(T copy)
        {
            var original = _originals[_copyIndex[copy]];
            return original.Equals(copy);
        }
        public IEnumerable<T> GetChangedItems()
        {
            return _copies.Values.Where(c => IsChanged(c));
        }
        public IEnumerable<T> GetTrackedItems()
        {
            return _copies.Values;
        }
        public void SetNewCheckpoint()
        {
            foreach (var copy in this.GetChangedItems().ToList())
            {
                int dbId = _copyIndex[copy];
                var oldOriginal = _originals[dbId];
                var newOriginal = (T)copy.Clone();
                _originals[dbId] = newOriginal;
                _originalIndex.Remove(oldOriginal);
                _originalIndex.Add(newOriginal, dbId);
            }
        }
        public void StartTracking(int dbId, T item)
        {
            var newOriginal = (T)item.Clone();
            _originals[dbId] = newOriginal;
            _originalIndex[newOriginal] = dbId;
            _copies[dbId] = item;
            _copyIndex[item] = dbId;
        }
        public void StopTracking(int dbId)
        {
            var original = _originals[dbId];
            var copy = _copies[dbId];
            _copies.Remove(dbId);
            _originals.Remove(dbId);
            _copyIndex.Remove(copy);
            _originalIndex.Remove(original);
        }
        public bool IsTracking(int dbId)
        {
            return _originals.ContainsKey(dbId);
        }
        public bool IsTracking(T item)
        {
            return _copyIndex.ContainsKey(item);
        }
    }
