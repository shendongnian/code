    public class MyController : ApiController
    {
        public IEnumerable<MyModel> Get([FromUri] MyComplexType input)
        {
            // input is not null as long as [FromUri] is present in the method arg
        }
    }
