    public class SomeWebServiceNameController : ApiController
    {
        SomeObject TheObject = new SomeObject();
        public string GetSomeData(string Param1, string Param2)
        {
            return TheObject.HandleRequest(Param1, Param2);
        }
        public string GetSomeMoreData(string ParamA)
        {
            return TheObject.HandleAnotherRequest(ParamA);
        }
        [HttpPost]
        public string PostSomeMoreData([FromBody]string ParamA)
        {
            return TheObject.HandleAnotherRequest(ParamA);
        }
    }
