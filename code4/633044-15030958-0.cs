    [ServiceContract]
    public interface ISampleTaskAsync
    {
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginDoWork(int count, AsyncCallback callback, object state);
     
        int EndDoWork(IAsyncResult result);
    }
