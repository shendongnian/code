    [TestFixture]
    public class TestClass
    {
      private Sut _sut;
      public TestClass()
      {
        _sut = new Sut(...);
      }
      private IEnumerable<object> TestCases
      {
        get
        {
          var values = new object[,] { { 1, "test", 3 }, { 2, "hello", 0 }, ... };
          for (var i = 0; i < values.GetLength(0); ++i)
          {
              yield return _sut.Method1((int)values[i,0]);
              yield return _sut.Method2((string)values[i,1]);
              yield return _sut.Method3((int)values[i,2]);
          }
        }
      }
      [TestCaseSource("TestCases")]
      public void Test(object val)
      {
        Assert.That(val, Is.Null);
      }
    }
