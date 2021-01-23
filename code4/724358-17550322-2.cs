    class Foo
    {
        //make static if this is called from different instances and should still
        //be synchronized
        private int isRunning = 0;
        public void DoStuff()
        {
            if (Interlocked.Exchange(ref isRunning, 1) == 0)
            {
                try
                {
                    DoRealStuff();
                }
                finally
                {
                    Interlocked.Exchange(ref isRunning, 0);
                }
            }
        }
    }
