    public class CheckAllService
    {
        // Make sure you don't create multiple 
        // instances of this class. Make it a singleton.
        // Holds all the pending requests
        private ConcurrentQueue<object> requests = new ConcurrentQueue<object>();
        private object syncLock = new object();
        private Thread checkAllThread;
        /// <summary>
        /// Requests to Check All. This request is async, 
        /// and will be serviced when all pending requests 
        /// are serviced (if any).
        /// </summary>
        public void RequestCheckAll()
        {
            requests.Enqueue("Process this Scotty...");
            lock (syncLock)
            {   // Lock is to make sure we don't create multiple threads.
                if (checkAllThread == null || 
                    checkAllThread.ThreadState != ThreadState.Running)
                {
                    checkAllThread = new Thread(new ThreadStart(ListenAndProcessRequests));
                    checkAllThread.Start();
                }
            }
        }
        private void ListenAndProcessRequests()
        {
            while (requests.Count != 0)
            {
                object thisRequestData;
                requests.TryDequeue(out thisRequestData);
                try
                {
                    CheckAllImpl();
                }
                catch (Exception ex)
                {
                    // TODO: Log error ?
                    // Can't afford to fail.
                    // Failing the thread will cause all 
                    // waiting requests to delay until another 
                    // request come in.
                }
            }
        }
        protected void CheckAllImpl()
        {
            throw new NotImplementedException("Check all is not gonna write it-self...");
            // TODO: Check All
        }
    }
