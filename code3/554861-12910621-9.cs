    using System;
    using System.Reflection;
    using A2;
    
    namespace A3
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine( A2Class.GetAssembly().FullName );
                Console.ReadLine();
            }
        }
    }
