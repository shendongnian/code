    using System;
    using System.Linq;
    using Microsoft.Deployment.WindowsInstaller;
    using Microsoft.Deployment.WindowsInstaller.Linq;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                using(var database = new QDatabase(@"C:\tfs\iswix.msi", DatabaseOpenMode.ReadOnly))
                {
                    var properties = from p in database.Properties
                                     select p;
    
                    foreach (var property in properties)
                    {
                        Console.WriteLine("{0} = {1}", property.Property, property.Value);
                    }
                }
                Console.Read();
            }
        }
    }
