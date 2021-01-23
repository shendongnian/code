    using System;
    
    namespace IfDebug
    {
        class Program
        {
            static void Main(string[] args)
            {
                string connectionString;
    
    #if DEBUG
                connectionString = "a";
    #else
                connectionString = "b";
    #endif
                Console.WriteLine(connectionString);
    
                Console.ReadLine();
            }
        }
    }
