    public class something
    {
      public int One { get;set; }
      public int Two { get;set; }
      
      public int Add()
      {
        return Add(One, Two);
      }
      
      internal static int Add(int one, int two) 
      {
        return one + two;
      }
    }
