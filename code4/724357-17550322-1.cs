    class Foo
    {
        //make static if this is called from different instances and should still
        //be synchronized
        private volatile bool isRunning = false;
        public void DoStuff()
        {
            if (!isRunning)
            {
                try
                {
                    isRunning = true;
                    DoRealStuff();
                }
                finally
                {
                    isRunning = false;
                }
            }
        }
    }
