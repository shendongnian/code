    public class Repository<T>
    {
        private Funct<T,int> _getPK;
        private Dictionary<int,T> _previousEntries;
        public Repository(Funct<T,int> getPK)
        {
            _getPK = getPK;
            _previousEntries = new Dictionary<int,T>();
        }
        public void Add(T item) {
            ...
            int pk = _getPK(item);
            T previousEntry;
            if (_previousEntries.TryGetValue(pk, out previousEntry) {
                // Update
            } else {
                // Add
                _previousEntries.Add(pk, item);
            }
        }
    }
