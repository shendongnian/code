    internal class TestClass
    {
        private ITestInterface testInterface;
        public TestClass(ITestInterface testInterface)
        { 
           this.testInterface = testInterface;
        }
        public bool Method1(int x)
        {
            testInterface.Method1(x);
            return true;
        }
    }
    
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            ITestInterface mockProxy = MockRepository.GenerateMock<ITestInterface>();
            TestClass tc = new TestClass(mockProxy);
            bool result = tc.Method1(5);           
            Assert.IsTrue(result);
            mockProxy.AssertWasCalled(x => x.Method1(5));
        }
    }
