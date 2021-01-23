    using System;
    using System.Linq;
    using Microsoft.Deployment.WindowsInstaller;
    using Microsoft.Deployment.WindowsInstaller.Linq;
    
    namespace ConsoleApplication3
    {
        class Program
        {
            const string DATABASE_PATH = @"C:\FOO..MSI";
            const string SQL_SELECT_PRODUCTVERSION = "SELECT `Value` FROM `Property` WHERE `Property`='ProductVersion'";
            
            static void Main(string[] args)
            {
                using (Database database = new Database(DATABASE_PATH, DatabaseOpenMode.ReadOnly))
                {
                    Console.WriteLine(database.ExecuteScalar(SQL_SELECT_PRODUCTVERSION).ToString());
                }
                using (QDatabase database = new QDatabase(DATABASE_PATH, DatabaseOpenMode.ReadOnly))
                {
                    var results = from property in database.Properties where property.Property == "ProductVersion" select property.Value;
                    Console.WriteLine(results.AsEnumerable<string>().First());                    
                }
            }
        }
    }
 
