    class Program
    {
      public static void Main()
      {
        DoSomething();
      }
    
      private static void DoSomething()
      {
        GetCallerInformation();
      }
    
      private static void GetCallerInformation(
          [CallerMemberName] string memberName = "",
          [CallerFilePath] string sourceFilePath = "",
          [CallerLineNumber] int sourceLineNumber = 0)  
      {
        Console.WriteLine("Member Name: " + memberName);
        Console.WriteLine("File: " + sourceFilePath);
        Console.WriteLine("Line Number: " + sourceLineNumber.ToString());
      }
    }
