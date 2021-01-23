    private class DoubleStringEnumerator : IEnumerator
    {
        private DoubleString _elemList;
        private int _index;
        public DoubleStringEnumerator(DoubleString doubleStringObjt)
        {
            _elemList = doubleStringObjt;
            _index = -1;
        }
        public void Reset()
        {
            _index = -1;
        }
        public object Current {
            get {
                return _elemList.getNext();
            }
        }
        public bool MoveNext ()
        {
            _index++;
            if (_index >= _elemList.Length)
                return false;
            else
                return true;
        }
    }
