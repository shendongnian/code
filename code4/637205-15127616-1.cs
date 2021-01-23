    public class Account
    {
        private readonly object lockThis = new object();
        public void ExecuteMe(List<Stuff> lNewStuff)
        {
            bool lockTaken = false;
            try
            {
                if (lNewStuff == null)
                {
                    // non-blocking - only takes the lock if it's available
                    Monitor.TryEnter(lockThis, ref lockTaken);
                }
                else
                {
                    // blocking - equivalent to the standard lock statement
                    Monitor.Enter(lockThis, ref lockTaken);
                }
                if (lockTaken)
                {
                    // main code processing
                }
            }
            finally
            {
                if (lockTaken)
                {
                    Monitor.Exit(lockThis);
                }
            }
        }
    }
