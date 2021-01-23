    public class EnumeratorList : IEnumerator
    {
        private object[] _list = new object[10];
        private int _currentIndex = -1;
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
