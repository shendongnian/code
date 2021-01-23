    namespace StatusSimulator
    {
          [ServiceContract]
          public interface IASDService
          {
               [OperationContract]
               public void DoWork()
          }
    
          [ServiceContract]
          public interface IScheduleTables
          {
                [OperatonContract]
                string getTable(string l, int r, int c)
                [OperatonContract]
                string getTable(string test)
                [OperatonContract]
                string createTable(List<string> lst, int r, int bal)
          }
    
          public class ServiceImplementation : IADSService, IScheduleTables
          {
             // implement both interfaces here...
          }
     }
