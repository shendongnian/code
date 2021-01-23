    [ServiceContract(Name = "IMyService", ...)]
    public interface IMyService {
       [OperationContract(IsOneWay=false)]
       SecurityOperationInfo LogonUser(string sessionId, string username, string password);
  
       // other methods ...
    }
    [ServiceContract(Name = "IMyService", ...)]
    public interface IMyServiceAsync : IMyService {
        [OperationContract(IsOneWay = false, AsyncPattern = true)]
        IAsyncResult BeginLogonUser(string sessionId, string username, string password, AsyncCallback callback, object state);        
        SecurityOperationInfo EndLogonUser(IAsyncResult result);
    }
