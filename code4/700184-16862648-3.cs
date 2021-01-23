    using System;
    internal class Program
    {
      public Program()
      {
        base..ctor();
      }
    
      public static implicit operator DateTime(Program x)
      {
        return new DateTime();
      }
    
      public static void Main(string[] args)
      {
        DateTime? nullable = new DateTime?((DateTime) new Program()); 
        Console.ReadKey(true);
      }
    }
