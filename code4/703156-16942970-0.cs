    public class EnterExitExample
    {
        private object myLock;
        private bool running;
        private void ThreadProc1()
        {
            while (running)
            {
                lock (myLock)
                {
                    // Do stuff here...
                }
                Thread.Yield();
            }
        }
        private void ThreadProc2()
        {
            while (running)
            {
                lock (myLock)
                {
                    // Do other stuff here...
                }
                Thread.Yield();
            }
        }
    }
