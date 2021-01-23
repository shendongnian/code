    public class Flattener<T> : IEnumerable<T>
    {
        private List<T> _collection = new List<T> ( );
        public void Add ( params T [ ] list )
        {
            _collection.AddRange ( list );
        }
        public void Add ( params IEnumerable<T> [ ] lists )
        {
            foreach ( var list in lists )
                _collection.AddRange ( list );
        }
        public IEnumerable<T> Result
        {
            get
            {
                return _collection;
            }
        }
        public IEnumerator<T> GetEnumerator ( )
        {
            return _collection.GetEnumerator ( );
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ( )
        {
            return GetEnumerator ( );
        }
    }
