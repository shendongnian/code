    [ServiceContract] 
    public interface ITest 
    { 
       [OperationContract] 
       string ShowMessage(string strMsg); 
     } 
   
    public class Service : ITest 
       { 
           public string ShowMessage(string strMsg) 
           { 
              return strMsg; 
           } 
       }
