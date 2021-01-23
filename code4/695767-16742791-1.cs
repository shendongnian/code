    public class GetCustomersHandler : IPendingServiceCallback
    {
        GetCustomersHandler()
        {
            this.Signal = new ManualResetEvent(false);
        }
        public void ResultReceived(IPendingServiceCall call)
        {
            this.Result = call.Result;
            this.Signal.Set();
        }
        public ManualResetEvent Signal { get; protected set; }
        public object Result { get; protected set; }
    }
