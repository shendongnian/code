    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace DAO_test
    {
        class Program
        {
            static void Main(string[] args)
            {
                // required COM reference: Microsoft Office 14.0 Access Database Engine Object Library
                var dbe = new Microsoft.Office.Interop.Access.Dao.DBEngine();
                Microsoft.Office.Interop.Access.Dao.Database db = dbe.Workspaces[0].OpenDatabase(@"C:\__tmp\testData.accdb");
                Microsoft.Office.Interop.Access.Dao.Field fld = db.TableDefs["poiData"].Fields["lon"];
                Console.WriteLine("Properties[\"DecimalPlaces\"].Value was: " + fld.Properties["DecimalPlaces"].Value);
                fld.Properties["DecimalPlaces"].Value = 5;
                Console.WriteLine("Properties[\"DecimalPlaces\"].Value is now: " + fld.Properties["DecimalPlaces"].Value);
                db.Close();
                Console.WriteLine("Hit a key...");
                Console.ReadKey();
            }
        }
    }
