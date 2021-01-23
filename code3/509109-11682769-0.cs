    using System;
    class LocalApplication
    {
      [STAThread]
      static void Main(string[] args)
      {
        Console.WriteLine(args[0]);
        Console.ReadLine();
      }
    }
