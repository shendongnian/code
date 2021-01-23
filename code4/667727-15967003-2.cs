    class Counter
    {
        private static int s_Number = 0;
        private static object _locker = new object();
        public static int GetNextNumber()
        {
            //Critical section
            return Interlocked.Increment(ref s_Number);
        }
    }
