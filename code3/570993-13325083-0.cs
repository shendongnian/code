    using System;
    using Microsoft.Win32;
    
    namespace ConsoleApplication1
    {
        internal class Program
        {
            public static void Main()
            {
                string[] values = Registry.LocalMachine.OpenSubKey(@"SOFTWARE").GetSubKeyNames();
    
                foreach (string value in values)
                {
                    Console.WriteLine(value);
                }
            }
        }
    }
