    public class GetCustomersHandler : IPendingServiceCallback
    {
        public void ResultReceived(IPendingServiceCall call)
        {
            this.Result = call.Result;
        }
        public object Result { get; protected set; }
    }
