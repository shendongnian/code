    class Test
    {
        private bool _loop = true;
    
        public static void Main()
        {
            Test test1 = new Test();
    
            // Set _loop to false on another thread
            new Thread(() => { test1._loop = false;}).Start();
    
            // Poll the _loop field until it is set to false
            while (test1._loop == true) ;
    
            // The loop above will never terminate!
        }
    }
