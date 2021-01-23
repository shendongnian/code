    class Foo
    {
        //make both static if this is called from different instances and should still
        //be synchronized
        private bool isRunning = false;
        private object key = new object();
        public void DoStuff()
        {
            lock (key)
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
    }
