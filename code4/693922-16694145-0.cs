    class Something
    {
        private int _testCount;
        public int TestCount
        {
            get { return _testCount; }
            set { _testCount = value; }
        }
        public void DoIt(int val)
        {
            _testCount = val;
        }
    }
