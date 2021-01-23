    [TestFixture]
    public class SampleFixture
    {
      public IEnumerable<int> GetData()
      {
        yield return 1;
        yield return 2;
        yield return 3;
      }
     
      [Test, Factory("GetData")]
      public void Test(int value)
      {
      }
    }
