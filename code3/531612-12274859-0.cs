    public class Trace 
    { 
      [Conditional("DEBUG")] 
      public static void Message(string traceMessage) 
      { 
        Console.WriteLine("[TRACE] - " + traceMessage); 
      } 
    } 
