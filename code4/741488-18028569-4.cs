    sealed class WorkerThread
    {
        public WorkerThread()
        {
            this.workItems = new Queue<Action>();
            this.workItemAvailable = new AutoResetEvent(initialState: false);
            new Thread(ProcessWorkItems) { IsBackground = true }.Start();
        }
    
        readonly Queue<Action> workItems;
        readonly AutoResetEvent workItemAvailable;
    
        public void QueueWorkItem(Action workItem)
        {
            lock (workItems)  // this is not extensively tested btw.
            {
                workItems.Enqueue(workItem);
            }
            workItemAvailable.Set();
        }
    
        void ProcessWorkItems()
        {
            for (;;)
            {
                workItemAvailable.WaitOne();
                Action workItem;
                lock (workItems)  // dito, not extensively tested.
                {
                    workItem = workItems.Dequeue();
                    if (workItems.Count > 0) workItemAvailable.Set();
                }
                workItem.Invoke();
            }
        }
    }
