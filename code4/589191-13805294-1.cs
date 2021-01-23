    using System;
    using Net2Library;
    
    namespace Net4App
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(Class1.GetStrings().GetType().AssemblyQualifiedName);
            }
        }
    }
