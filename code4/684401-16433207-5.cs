    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerCall)]
    public class SimpleService : ISimpleService
    {
        public string ProcessData()
        {
            // Get a handle to the call back channel
            var callback = OperationContext.Current.GetCallbackChannel<IMyCallbackService>();
            callback.NotifyClient();
            return DateTime.Now.ToString();
        }
    }
