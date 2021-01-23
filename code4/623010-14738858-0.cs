    [ServiceContract()]
    interface IService1
    {
        [OperationContract]
        ReturnValue GetValuesForCalculation(int value1, int value2, int value3, int value4, int value5);
    }
    
    
    public class Service1 : IService1
    {
        public ReturnValue GetValuesForCalculation(int value1, int value2, int value3, int value4, int value5)
        {
            int AddedResult;
            int SubtractedResult;
            int MultipliedResult;
            int DividedResult;
    
            AddedResult = (value1 + value2);
            SubtractedResult = (AddedResult - value3);
            MultipliedResult = (SubtractedResult - value4);
            DividedResult =(MultipliedResult/value5);
    
            var returnValue = new ReturnValue(AddedResult, SubtractedResult, MultipliedResult,DividedResult); 
    
            return returnValue ;
        }
    }
    
    [DataContract]
    public class ReturnValue
    {
        public ReturnValue(int addedResult, int subtractedResult, int multipliedResult, int dividedResult)
        {
            AddedResult = addedResult;
            SubtractedResult = subtractedResult;
            MultipliedResult = multipliedResult;
            DividedResult = dividedResult;
        }
    
        public int AddedResult {get; set;}
        public int SubtractedResult {get; set;}
        public int MultipliedResult {get; set;}
        public int DividedResult {get; set;}
    }
