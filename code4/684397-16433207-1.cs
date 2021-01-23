    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerCall)]
    public class SimpleService : ISimpleService
    {
        public string ProcessData()
        {
            var callback = OperationContext.Current.GetCallbackChannel<IMyCallbackService>();
            callback.NotifyClient();
            return DateTime.Now.ToString();
        }
    }
