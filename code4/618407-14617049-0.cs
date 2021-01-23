    using System;
    using Microsoft.Deployment.WindowsInstaller;
    using Microsoft.Deployment.WindowsInstaller.Package;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var package = new InstallPackage("foo.msi", DatabaseOpenMode.ReadOnly))
                {
                    foreach (var filePath in package.Files)
                    {
                        Console.WriteLine(filePath.Value);
                    }
                    Console.WriteLine("Finished");
                    Console.Read();
                }
            }
        }
    }
