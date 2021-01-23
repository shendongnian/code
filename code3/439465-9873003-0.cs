    [ServiceContract] 
    [AspNetCompatibilityRequirments(RequirmentsMode = ApsNetCompatibilityRequirments.Allowed)] public interface IConsumerResponder { 
        [OperationConract]   
        public List<string> GetStrings(int a, int b, int c);
    } 
 
----------
   
    public class ConsumerResponder:IConsumerResponder
    {
       public List<string> GetStrings(int a, int b, int c) {  
           return new List<string>;     }
    }
