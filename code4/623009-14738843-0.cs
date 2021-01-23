    public class Service1 : IService1
    {
    public int GetValuesForCalculation(int value1, int value2, int value3, int value4, int value5)
    {
        int AddedResult;
        int SubtractedResult;
        int MultipliedResult;
        int DividedResult;
        AddedResult = (value1 + value2);
        SubtractedResult = (AddedResult - value3);
        MultipliedResult = (SubtractedResult - value4);
        DividedResult =(MultipliedResult/value5);
        CallResponse myResponse = new CallREsponse {AddResult = AddedResult, 
					 SubtractResult = SubtractedResult, 
					 MultiplyResult = MultipliedResult, 
					 DivideResult = DividedResult};
        return myResponse;
    }
    }
    public struct CallResponse
    {
	int AddResult;
        int SubtractResult;
        int MultiplyResult;
        int DivideResult;
    }
