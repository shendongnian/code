    [TestFixture("some param", 123)]
    [TestFixture("another param", 456)]
    public class SomeTestsClass
    {
        private readonly string _firstParam;
        private readonly int _secondParam;
        public WhenNoFunctionCodeExpected(string firstParam, int secondParam)
        {
            _firstParam = firstParam;
            _secondParam = secondParam;
        }
        [Test]
        public void SomeTestCase()
        {
            ...
        }
    }
