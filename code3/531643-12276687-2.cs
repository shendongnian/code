    class MyClass
    {
        static int counter = 0;
        static object lockObject = new object();
    
        public MyClass()
        {
            Interlocked.Increment(ref counter);
        }
    
        public ~MyClass()
        {
            Interlocked.Decrement(ref counter);
        }
    }
