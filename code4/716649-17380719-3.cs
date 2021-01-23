     [ServiceContract]
     public interface IService2
     {
         [OperationContract(IsOneWay = true)]
         void DoSomething(int value);
     }
