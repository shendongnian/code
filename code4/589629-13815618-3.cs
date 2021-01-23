    class Wrapper : IEnumerable<int>
    {
        private readonly List<int> _list = new List<int>();
        public IEnumerator<int> GetEnumerator()
        {
            return _list.GetEnumerator();
        }
        // Explicit implementation of non-generic interface
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Add(int item)
        {
            _list.Add(item);
        }
    }
