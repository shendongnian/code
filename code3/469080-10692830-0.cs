    using System;
    using System.IO;
    
    namespace CurrentDirTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(Environment.CurrentDirectory);
                Console.WriteLine(Directory.GetCurrentDirectory());
                Console.WriteLine(System.Threading.Thread.GetDomain().BaseDirectory);
                Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
                Console.ReadLine();
            }
        }
    }
