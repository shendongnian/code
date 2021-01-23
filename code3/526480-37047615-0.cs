    interface IAInterface
    {
      void PrintIt(string s);
    }
    interface IBInterface
    {
      void PrintIt(string s);
    }
    class MyClass : IAInterface, IBInterface
    {
      public void PrintIt(string s)
      {
        Console.WriteLine(s);
      }  
    }
