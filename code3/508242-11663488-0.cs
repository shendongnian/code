    public abstract class Task
    {
        protected Thread InternalThread { get; set; }
        protected abstract void Run();
                
        public void Start()
        {
            this.InternalThread = new Thread(this.Run);
            this.InternalThread.Start();    
        }
    }
