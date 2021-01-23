    public class TestClass2
    {
        private string _testValue;
        public static TestClass2 Create(TestClass1 input)
        {
            TestClass2 output = new TestClass2();
            output._testValue =  ((ITestInterface)input).TestValue;
            return output;
        }
    }
