    // IWcfProcessor is the ServiceContract interface
    // Processor runs as a singleton and does (or has a thread that does) the processing work
    class Processor : IWcfProcessor
    {
        public Processor()
        {
            new Thread(Process).Start();
        }
        public void Process()
        {
            while (Run)
            {
                // Do long-running process stuff, update some tables
                PercentDone += 0.1;
            }
        }
        public decimal PercentDone { get; set; }
        public bool Run { get; set; }
        /// WCF method defined in IWcfProcessor
        public void SetState(bool state)
        {
            Run = state;
        }
        /// WCF method defined in IWcfProcessor
        public decimal GetStatus()
        {
            return PercentDone;
        }
    }
  
