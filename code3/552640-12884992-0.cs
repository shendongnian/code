    [Cmdlet("Test", "Adapter")]
    class TestCmdlet : PSCmdlet
    {
        protected override void ProcessRecord()
        {
            PowerShellAdapter adapter = new PowerShellAdapter(this);
            Task.Factory.StartNew(() => {
                for (int x = 0; x < 100; x++)
                    adapter.WriteObject(x);
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
        public PowerShellAdapter(Cmdlet cmdlet)
        {
            this.Cmdlet = cmdlet;
            this.LockToken = new object();
            this.Queue = new Queue<object>();
            this.Finished = false;
        }
        public void Listen()
        {
            while (!Finished || Queue.Count > 0)
            {
                while (Queue.Count > 0)
                    Cmdlet.WriteObject(Queue.Dequeue());
                Thread.Sleep(250);
            }
        }
        public void WriteObject(object obj)
        {
            lock (LockToken)
                Queue.Enqueue(obj);
        }
