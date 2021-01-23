    using System;
    using Net2Library;
    
    namespace Net4Application
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("From Net4Application: {0}", Class1.GetStrings().GetType().AssemblyQualifiedName);
            }
        }
    }
