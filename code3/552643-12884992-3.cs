    [Cmdlet("Test", "Adapter")]
    public class TestCmdlet : PSCmdlet
    {
        protected override void ProcessRecord()
        {
            PowerShellAdapter adapter = new PowerShellAdapter(this, 100);
            Task.Factory.StartNew(() => {
                for (int x = 0; x < 100; x++) {
                    adapter.WriteObject(x);
                    Thread.Sleep(100);
                }
                adapter.Finished = true;
            });
            adapter.Listen();
        }
    }   
 
---
    public class PowerShellAdapter
    {
        private Cmdlet Cmdlet { get; set; }
        private Queue<object> Queue { get; set; }
        private object LockToken { get; set; }
        public bool Finished { get; set; }
        public int Total { get; set; }
        public int Count { get; set; }
        public PowerShellAdapter(Cmdlet cmdlet, int total)
        {
            this.Cmdlet = cmdlet;
            this.LockToken = new object();
            this.Queue = new Queue<object>();
            this.Finished = false;
            this.Total = total;
        }
        public void Listen()
        {
            ProgressRecord progress = new ProgressRecord(1, "Counting to 100", " ");
            while (!Finished || Queue.Count > 0)
            {
                while (Queue.Count > 0)
                {
                    progress.PercentComplete = ++Count*100 / Total;
                    progress.StatusDescription = Count + "/" + Total;
                    Cmdlet.WriteObject(Queue.Dequeue());
                    Cmdlet.WriteProgress(progress);
                }
                Thread.Sleep(100);
            }
        }
        public void WriteObject(object obj)
        {
            lock (LockToken)
                Queue.Enqueue(obj);
        }
    }
