    [TestClass]
    public class TestClass
    {
        Dictionary<string, string> testMethods;
        bool testResult;
        [TestInitialize]
        public void TestInitialize()
        {
            testMethods = new Dictionary<string, string>();
            testResult = true;
        }
        [TestMethod]
        public void TestMethod()
        {
            //Run TestMethodA
            try
            {
                TestMethodA();
                testMethods.Add("TestMethodA", "Passed");
            }
            catch (AssertFailedException exception)
            {
                testResult = false;
                testMethods.Add("TestMethodA", "Failed: " + exception.Message);
            }
            //Run TestMethodB
            try
            {
                TestMethodB();
                testMethods.Add("TestMethodB", "Passed");
            }
            catch (AssertFailedException exception)
            {
                testResult = false;
                testMethods.Add("TestMethodB", "Failed: " + exception.Message);
            }
            ...
        }
        [TestCleanup]
        public void TestCleanup()
        {
            foreach (KeyValuePair<string, string> testMethod in testMethods)
            {
                //Print the result for each test method
                TestContext.WriteLine(testMethod.Key.ToString() + " --> " + testMethod.Value.ToString());
            }
            if (!testResult)
            {
                //Assert if the parent test was passed or not.
                Assert.Fail("One or more inner tests were failed.");
            }
        }
    }
