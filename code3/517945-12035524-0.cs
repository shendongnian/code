    public string RunCodeReturnConsoleOut(Action code) 
    {
      string result;
      var originalConsoleOut = Console.Out;
      try 
      {
        using (var writer = new StringWriter()) 
        {
          Console.SetOut(writer);
          code();
          writer.Flush();
          result = writer.GetStringBuilder().ToString();
        }
        return result;
      }
      finally 
      {
        Console.SetOut(originalConsoleOut); 
      }
    }
