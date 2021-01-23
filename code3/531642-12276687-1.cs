    class MyClass
    {
        static int counter = 0;
        static object lockObject = new object();
    
        public MyClass()
        {
            lock (lockObject) ;
            {
                counter++;
            }
        }
    
        public ~MyClass()
        {
            lock (lockObject) ;
            {
                counter--;
            }
        }
    }
