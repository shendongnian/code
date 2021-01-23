    public class Account
    {
        private readonly object lockThis = new object();
        public void ExecuteMe(List<Stuff> lNewStuff)
        {
            if (lNewStuff == null)
            {
                bool lockTaken = false;
                try
                {
                    Monitor.TryEnter(lockThis, ref lockTaken);
                    if (lockTaken) ExecuteMeImpl(lNewStuff);
                }
                finally
                {
                    if (lockTaken) Monitor.Exit(lockThis);
                }
            }
            else
            {
                lock (lockThis)
                {
                    ExecuteMeImpl(lNewStuff);
                }
            }
        }
        private void ExecuteMeImpl(List<Stuff> lNewStuff)
        {
            // main code processing
        }
    }
