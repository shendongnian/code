     [ServiceContract]
     public interface IService1
     {
         [OperationContract(IsOneWay = true, AsyncPattern = true)]
         IAsyncResult BeginDoSomething(int value, AsyncCallback callback, object state);
    
         void EndDoSomething(IAsyncResult result);
     }
