    using System;
    using System.IO;
    using Microsoft.Deployment.WindowsInstaller;
    
    namespace ConsoleApplication1
    {
        
        class Program
        {
            const string REFERENCEDATABASE = @"C:\orig.msi";
            const string TEMPDATABASE = @"C:\temp.msi";
            const string TRANSFORM = @"c:\foo.mst";
    
            static void Main(string[] args)
            {
                File.Copy(REFERENCEDATABASE, TEMPDATABASE, true);
                using (var origDatabase = new Database(REFERENCEDATABASE, DatabaseOpenMode.ReadOnly))
                {
                    using (var database = new Database(TEMPDATABASE, DatabaseOpenMode.Direct))
                    {
                        database.Execute("Update `Property` Set `Property`.`Value` = 'Test' WHERE `Property`.`Property` = 'ProductName'");
                        database.GenerateTransform(origDatabase, TRANSFORM);
                        database.CreateTransformSummaryInfo(origDatabase, TRANSFORM, TransformErrors.None, TransformValidations.None);
                    }
                }
            }
        }
    }
