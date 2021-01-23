    class Counter
    {
        private static int s_Number = 0;
        private object _locker = new object();
        public static int GetNextNumber()
        {
        //Critical section
        lock(_locker)
            {
                s_Number++;
                return s_Number;
            }
        }
    }
