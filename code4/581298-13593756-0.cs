    public class Repository<T>
    {
        private Funct<T,int> _getPK;
        public Repository(Funct<T,int> getPK)
        {
            _getPK = getPK;
        }
        public void Add(T item) {
            ...
            int pk = _getPK(item);
            var previousRow = _previousEntries.Single(n => _getPK(n) == pk);
            ...
        }
    }
