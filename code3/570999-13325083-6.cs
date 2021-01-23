    using System;
    using Microsoft.Win32;
    
    namespace ConsoleApplication1
    {
      internal class Program
      {
        public static void Main()
        {
          String[] values = Registry.LocalMachine.OpenSubKey(@"SOFTWARE").GetSubKeyNames();
          foreach (String value in values)
                    Console.WriteLine(value);
        }
      }
    }
