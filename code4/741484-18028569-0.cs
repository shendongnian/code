    sealed class WorkerThread
    {
        public WorkerThread()
        {
            this.thread = new Thread(ProcessWorkItems) { IsBackground = true };
            this.workItems = new Queue<Action>();
            this.workItemAvailable = new AutoResetEvent(initialState: false);
        }
    
        readonly Thread thread;
        readonly Queue<Action> workItems;
        readonly AutoResetEvent workItemAvailable;
    
        public void Start()
        {
            thread.Start();
        }
    
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
