    [ServiceContract]
    public interface IService
    {
       [OperationContract(Action = "*", ReplyAction = "*")]
       Message Action(Message m);
    }
    
    [ErrorBehavior(typeof(HttpErrorHandler))]
    public class Service : IService
    {
       public Message Action(Message m)
       {
          throw new FaultException("!");
       }
    }
