    class ListWrapper :IEnumerable<int>
    {
        private List<int> _list = new List<int>();
        public void Add(int i)
        {
            _list.Add(i);
        }
        public IEnumerator<int> GetEnumerator()
        {
            return _list.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
