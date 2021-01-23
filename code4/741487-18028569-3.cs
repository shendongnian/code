    class Consumer
    {
        public void SubscribeToEventOf(Producer producer, WorkerThread targetWorkerThread)
        {
            producer.Event += delegate(object sender, EventArgs e)
            {
                targetWorkerThread.QueueWorkItem(() => OnEvent(sender, e));
            };
        }
    
        protected virtual void OnEvent(object sender, EventArgs e)
        {
            // this code is executed on the worker thread(s) passed to `SubscribeTo`. 
        }
    }
