    class Program
    {
        static void Main(string[] args)
        {
            something s = new something();
            s.DoIt(10);
            Console.Write(s.testCount);
        }
    }
    
    class something
    {
        private int _testCount;
    
        public int testCount
        {
            // you are calling the property within the property which would be why you have a stack overflow.
            get { return _testCount; }
            set { _testCount = value + 13; }
        }
    
        public void DoIt(int val)
        {
            testCount = val;
        }
    }
