    public class EnumerableList : IEnumerable
    {
        private object[] _list = new object[10];
        public IEnumerator GetEnumerator()
        {
            return new ListEnumerator(this);
        }
        private class ListEnumerator : IEnumerator
        {
            private EnumeratorList _list;
            private int _currentIndex = -1;
            public ListEnumerator(EnumeratorList list)
            {
                _list = list;
            }
            public object Current { get { return _list[_currentIndex] } };
            public bool MoveNext()
            {
                return ++_currentIndex < 10;
            }
            public void Reset()
            {
                _currentIndex = -1;
            }
        }
    }
