    using System;
    using System.Reflection;
    using NUnit.Framework;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var assemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
                foreach (var assemblyName in assemblies)
                {
                    Console.WriteLine(assemblyName.FullName);
                }
                Console.ReadKey();
            }
        }
    }
