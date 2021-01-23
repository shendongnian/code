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
    
                using (var database = new Database(@"C:\tfs\iswix.msi", DatabaseOpenMode.ReadOnly))
                {
                    using(var view = database.OpenView(database.Tables["Property"].SqlSelectString))
                    {
                        view.Execute();
                        foreach (var rec in view) using (rec)
                        {
                            Console.WriteLine("{0} = {1}", rec.GetString("Property"), rec.GetString("Value"));
                        }
                    }
                }
                
                Console.Read();
            }
        }
    }
