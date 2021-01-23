    public class MyStepDefs
    {
        private readonly TestContext _testContext;
        public MyStepDefs(TestContext testContext) // use it as ctor parameter
        { 
            _testContext = testContext;
        }
    
        [BeforeScenario()]
        public void BeforeScenario()
        {
            //now you can access the TestContext
        } 
    }
