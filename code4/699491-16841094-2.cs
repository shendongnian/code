    public static class MyClass
    {
        private static readonly object locker = new object();
    
        private static string someProperty;
    
        public void SetSomeProperty(string val)
        {
            lock (locker)
            {
                 someProperty = val;
            }
        }
    
        public void GetSomeProperty()
        {
            lock (locker)
            {
                 return someProperty;
            }
        }
    }
