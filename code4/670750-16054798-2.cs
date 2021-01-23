      [ServiceContract]
      public interface IService
      {
         [OperationContract]
         SendMessage(Messageformat message);
      }
