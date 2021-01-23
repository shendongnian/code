    public class SingleTestFilter : TestFilter
    {
        private string testName;
        public SingleTestFilter(string TestName)
        {
            testName = TestName;
        }
        public override bool Match(ITest test)
        {
            return test.TestName.Name.Equals(testName);
        }
    }
