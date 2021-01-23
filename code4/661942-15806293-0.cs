    [TestClass]
    [DeploymentItem("MyFiles")]
    public class MyClassTest
    {
        [TestMethod]
        public SomeMethodTest()
        {
            // Your unit test.
        }
    
        [TestMethod]
        [DeploymentItem("MyFiles")]
        public AnotherMethodTest()
        {
            // Your unit test.
        }
    }
