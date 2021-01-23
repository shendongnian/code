    using System.Diagnostics;
    private static void Main(string[] args) {
      DoWork();
      
      if (Debugger.IsAttached) {
        Console.WriteLine("Press any key to continue . . .");
        Console.ReadLine();
      }
    }
