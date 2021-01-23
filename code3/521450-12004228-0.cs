    class AsyncWorker
    {
        public void BeginWork()
        {
            new TaskFactory().StartNew(() => RaiseEvent());
        }
    
        public event EventHandler MyEvent;
    }
    var worker = new AsyncWorker();
    worker.MyEvent += (s, e) =>
                      {
                          /* I will be executed on the thread
                             started by the TaskFactory */
                      };
    worker.BeginWork();
