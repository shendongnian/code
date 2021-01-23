    public class TestDerived : Test<object>
    {
    }
    public class TestDerivedManager : ITesting<object>
    {
      public TestDerived LoadTest()
      {
        return new TestDerived();
      }
      Test<object> ITesting<object>.LoadTest()
      {
        return this.LoadTest();
      }
    }
