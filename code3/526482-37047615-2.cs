    class MyClass : IAInterface, IBInterface
    {
      public void IAInterface.PrintIt(string s)
      {
        Console.WriteLine("AInterface - {0}", s);
      } 
      public void IBInterface.PrintIt(string s)
      {
        Console.WriteLine("BInterface - {0}", s);
      }   
    }
