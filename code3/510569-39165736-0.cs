    public static class TestCasesData 
    { 
      public static string[] TestStringsData() 
      {
           return new string[] {"TEST1", "TEST2"};
      }
    }
    
    [TestFixture]
    public class MyTest
    {
         [Test]
         [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestStringsData))]
         public void TestCase1(...)
         {
         }
    }
