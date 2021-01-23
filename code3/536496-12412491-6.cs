    static class Throttle
    {
        public static void RunExclusive(ref int isRunning, Action action)
        {
            if (isRunning > 0) return;
            bool locked = false;
            try
            {
                try { }
                finally
                {
                    locked = Interlocked.CompareExchange(ref isRunning, 1, 0) == 0;
                }
                
                if (locked) action();
            }
            finally 
            { 
                if (locked) 
                    Interlocked.Exchange(ref isRunning, 0); 
            }
        }
    }
