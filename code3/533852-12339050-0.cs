    public abstract class FooTestsBase
    {
        protected abstract IFoo GetTestedInstance();
        [Fact]
        public void TestDoSomeStuff()
        {
            var testedInstance = GetTestedInstance();
            // ...
        }
    }
