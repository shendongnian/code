    class PrintJob
    {
        public PrintJob()
        { 
            Event = new ManualResetEventSlim();
        }
        public ManualResetEventSlim Event {get; private set;}
        
        public int Status{ get; set;}
    }
