    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace adoxTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                string myConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data source=C:\__tmp\myDB.accdb;";
    
                // the following code requires a COM reference to "Microsoft ADO Ext. 2.8 for DDL and Security"
                var cat = new ADOX.Catalog();
                cat.Create(myConnectionString);  // create a new, empty .accdb file
    
                Console.WriteLine("Done.");
            }
        }
    }
