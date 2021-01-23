    public class TestController : ApiController
    {
        private readonly ITestDomainService TestDomainService;
        public TestController(ITestDomainService testDomainService)
        {
            this.TestDomainService = testDomainService;
        }
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return TestDomainService.GetSomething();
            //return new string[] { "value1", "value2" };
        }
    }
