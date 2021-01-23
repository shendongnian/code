    class MyClass
    {
        static int counter = 0;
    
        public MyClass()
        {
            Interlocked.Increment(ref counter);
        }
    
        ~MyClass()
        {
            Interlocked.Decrement(ref counter);
        }
    }
