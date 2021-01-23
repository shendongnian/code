    using Microsoft.Deployment.WindowsInstaller;
    using Microsoft.Deployment.WindowsInstaller.Package;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                using( var package = new InstallPackage(@"C:\test.msi", DatabaseOpenMode.ReadOnly))
                {
                    package.ExtractFiles();
                }
            }
        }
    }
