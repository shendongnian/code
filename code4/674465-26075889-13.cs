    public class TestController : ApiController
    {
        private readonly ITestService TestService;
        public TestController(ITestService testService)
        {
            this.TestService = testService;
        }
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return TestService.GetSomething();
            //return new string[] { "value1", "value2" };
        }
    }
