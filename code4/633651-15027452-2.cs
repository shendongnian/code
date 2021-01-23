    public class TestList<T> : IEnumerable<T>
    {
        private TestEnumerator<T> _Enumerator;
        public TestList()
        {
            _Enumerator = new TestEnumerator<T>();
        }
            
        public IEnumerator<T> GetEnumerator()
        {
            return _Enumerator;
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        internal void Add(T p)
        {
            _Enumerator.Add(p);
        }
    }
