    public class TestDerivedManager : ITesting<object>
    {
        public Test<object> LoadTest()
        {
            return new TestDerived();
        }
    }
