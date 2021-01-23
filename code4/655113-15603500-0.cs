    using System;
    using System.Reflection;
    
    namespace TestLocation
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("{0}", Assembly.GetExecutingAssembly().Location);
            }
        }
    }
