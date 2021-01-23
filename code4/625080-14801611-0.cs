    [ServiceContract]
    public interface ILogCallback
    {
        [OperationContract(IsOneWay = true)]
        void NewLog(string logString);
    }
    
    [ServiceContract(CallbackContract = typeof(ILogCallback))]
    public interface ILog
    {
        /// Call this method to sign up for future log messages, 
        /// which will be sent to the callback NewLog.
        [OperationContract]
        void SignMeUpForLogs();
    }
