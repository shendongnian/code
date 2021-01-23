    namespace ITHelperService
    {
     [ServiceContract]
     [ServiceKnownType(typeof(ITHelperService.Service.CommandsEnums))]
     public interface IService
     {
      [OperationContract]
      void Test();
     }
    }
