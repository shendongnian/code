    static void Main() 
    {
      try
      {
          int i = 0;
          try
          {
             int j = 1 / i; // Generate a divide by 0 exception.
          }
          finally
          {
              Console.Out.WriteLine("Finished");
              Console.In.ReadLine();     
          }
      }
      catch (Exception ex)
      {
          Console.WriteLine(ex.ToString());
      }
    }
