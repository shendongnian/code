    [TestFixture()]
    public class SpecificDatabaseTest : IDatabase
    {
        private SpecificDatabase testObject = new SpecificDatabase();
        private object TestObject = new object();
        private SomeObject TestSomeObject1 = new SomeObject();
        private SomeObject TestSomeObject2 = new SomeObject();
        
        public IEnumerable<TestCaseData> SomeMethodData
        {
            get
            {
                yield return new TestCaseData(TestObject).Returns(TestObject);    
            }
        }
        
        public IEnumerable<TestCaseData> SomeOtherMethodData
        {
            get
        	{
        	    yield return new TestCaseData(TestSomeObject1, TestSomeObject2).Returns(TestSomeObject2);
        	    yield return new TestCaseData(TestSomeObject2, TestSomeObject1).Returns(TestSomeObject1);
        	}
        }
        
        [Test, TestCaseSource(nameof(SomeMethodData))]
        public object SomeMethod(object data)
        {
            return testObject.SomeMethod(data);
        }
    
        [Test, TestCaseSource(nameof(SomeOtherMethodData))]
        public SomeObject SomeOtherMethod(SomeObject data1, SomeObject data2)
        {
            return testObject.SomeOtherMethod(data1, data2);
        }
    }
