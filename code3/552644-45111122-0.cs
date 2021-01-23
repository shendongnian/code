    using System.Threading;
    public class PowerShellAdapter
    {
        private Cmdlet Cmdlet { get; set; }
        private Queue<object> Queue { get; set; }
        AutoResetEvent sync;
        private object LockToken { get; set; }
        // volatile, since it will be written/read from different threads.
        volatile bool finished;
        public bool Finished
        {
            get { return finished; }
            set
            {
                this.finished = value;
                // allow the main thread to exit the outer loop.
                sync.Set();
            }
        }
        public int Total { get; set; }
        public int Count { get; set; }
    
        public PowerShellAdapter(Cmdlet cmdlet, int total)
        {
            this.Cmdlet = cmdlet;
            this.LockToken = new object();
            this.Queue = new Queue<object>();
            this.finished = false;
            this.Total = total;
            this.sync = new AutoResetEvent(false);
        }
    
        public void Listen()
        {
            ProgressRecord progress = new ProgressRecord(1, "Counting to 100", " ");
            while (!Finished)
            {
                while (true) { // loop until we drain the queue
                    object item;
                    lock (LockToken) {
                        if (Queue.Count == 0)
                            break; // exit while
                        item = Queue.Dequeue();
                    }
    
                    progress.PercentComplete = ++Count * 100 / Total;
                    progress.StatusDescription = Count + "/" + Total;
                    Cmdlet.WriteObject(item);
                    Cmdlet.WriteProgress(progress);
                }
                sync.WaitOne();// wait for more data to become available
            }
        }
    
        public void WriteObject(object obj)
        {
            lock (LockToken)
            {
                Queue.Enqueue(obj);
            }
            sync.Set(); // alert that data is available
        }
    }
