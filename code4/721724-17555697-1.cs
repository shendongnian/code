    public class SomeWebServiceNameController : ApiController
    {
        SomeObject TheObject = new SomeObject;
    
        [HttpGet]
        public string GetSomeData(string Param1, string Param2)
        {
             return TheObject.HandleRequest(Param1, Param2);
        }
    
        [HttpGet]
        public string GetSomeMoreData(string ParamA)
        {
             return TheObject.HandleAnotherRequest(ParamA);
        }
    }
