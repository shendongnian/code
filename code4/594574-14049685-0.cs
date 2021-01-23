    static class TestSideEffects
    {
        public static void Test()
        {
            Console.WriteLine("Main Thread: {0}", Thread.CurrentThread.ManagedThreadId);
            var o = new TestSubject();
            Console.WriteLine("Property Value: {0}", o.IntGetValueNoSe());
        }
    }
    class TestSubject
    {
        private int _prop=0;
        public int TheProperty
        {
            get
            {
                Console.WriteLine("Thread accessing the property: {0}", Thread.CurrentThread.ManagedThreadId);
                return ++_prop;
            }
        } 
        public int IntGetValueNoSe(){return _prop; }
    }
