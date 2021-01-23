    // IWcfProcessor is the ServiceContract interface
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
  
