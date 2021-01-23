    public interface ITest 
    {
      void Test(string testInput);
    }
    public class TestImpl : ITest
    {
      public int TestId { get; private set; }
      void ITest.Test(string testInput)
      {
        int intOut; //I think this is your point of confusion, right?
        if (!int.TryParse(testInput, out intOut))
          return;
        TestId = intOut; 
      } 
    }
