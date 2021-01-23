    void Main()
    {
      ATest t = new ATest();
      Experiment z = new Experiment();
      
      z.TestTest(t);
    }
    
    public class ATest : ITest
    {
      public dynamic Data {get; set;}
      
      public ATest()
      {
         Data = new { Test = "This is a string" };
      }
    }
    
    // Define other methods and classes here
    public interface ITest
    {
      dynamic Data { get; }
    }
        
    public class Experiment
    {
        public int TestTest(ITest context)
        {
           dynamic data = context.Data; 
           
           Console.WriteLine(data.Test);
                
           return 0;
        }
    }
