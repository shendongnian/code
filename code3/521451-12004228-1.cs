    class AsyncWorker
    {
        public void BeginWork()
        {
            new TaskFactory().StartNew(() => RaiseMyEvent());
        }
    
        public event EventHandler MyEvent;
        private void RaiseMyEvent()
        {
            var myEvent = MyEvent;
            if(myEvent != null)
                myEvent(EventArgs.Empty);
        }
    }
    var worker = new AsyncWorker();
    worker.MyEvent += (s, e) =>
                      {
                          /* I will be executed on the thread
                             started by the TaskFactory */
                      };
    worker.BeginWork();
