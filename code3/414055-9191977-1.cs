    static void Main()
    {
      try
      {
        StackOverflow();
      }
      catch (Exception ex)
      {
        // This line will NEVER execute.
        Console.WriteLine("Caught {0}", ex);
      }
    }
    static void StackOverflow() { StackOverflow(); }
