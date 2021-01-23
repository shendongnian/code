    class HugeList<T>
    {
        private const int PAGE_SIZE = 102400;
        private const int ALLOC_STEP = 1024;
        private T[][] _rowIndexes;
        private int _currentPage = -1;
        private int _nextItemIndex = PAGE_SIZE;
        private int _pageCount = 0;
        private int _itemCount = 0;
        #region Internals
        private void AddPage()
        {
            if (++_currentPage == _pageCount)
                ExtendPages();
            _rowIndexes[_currentPage] = new T[PAGE_SIZE];
            _nextItemIndex = 0;
        }
        private void ExtendPages()
        {
            if (_rowIndexes == null)
            {
                _rowIndexes = new T[ALLOC_STEP][];
            }
            else
            {
                T[][] rowIndexes = new T[_rowIndexes.Length + ALLOC_STEP][];
                Array.Copy(_rowIndexes, rowIndexes, _rowIndexes.Length);
                _rowIndexes = rowIndexes;
            }
            _pageCount = _rowIndexes.Length;
        }
        #endregion Internals
        #region Public
        public int Count
        {
            get { return _itemCount; }
        }
        public void Add(T item)
        {
            if (_nextItemIndex == PAGE_SIZE)
                AddPage();
            _itemCount++;
            _rowIndexes[_currentPage][_nextItemIndex++] = item;
        }
        public T this[int index]
        {
            get { return _rowIndexes[index / PAGE_SIZE][index % PAGE_SIZE]; }
            set { _rowIndexes[index / PAGE_SIZE][index % PAGE_SIZE] = value; }
        }
        #endregion Public
    }
