       [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class DuplexService : IDuplexService
    {
        IDuplexCallback _callback;
        string _requestString = String.Empty;
        public DuplexService()
        {
            _callback = OperationContext.Current.GetCallbackChannel<IDuplexCallback>();
        }
        public void FormatString(string text)
        {
            //Make the thread to sleep for 10 seconds
            Thread.Sleep(4000);
            //Format the input data
            _requestString = string.Format("Welcome to {0}", text);
            //Pass the string to the client through the call back function
            _callback.DuplexCallbackFunction(_requestString);
        }
    }
