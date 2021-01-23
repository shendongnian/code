    using System;
    using System.Linq;
    using System.Data.OleDb;
    using System.Data.Common;
    using Newtonsoft.Json;
    using System.IO;
    
    namespace ConsoleApplication1 {
        class Program {
            static void Main(string[] args) {
                var pathToExcel = @"C:\path\to\excel\file.xlsx";
                var sheetName = "NameOfSheet";
                var destinationPath = @"C:\path\to\save\json\file.json";
    
                //This connection string works if you have Office 2007+ installed and your 
                //data is saved in a .xlsx file
                var connectionString=String.Format(@"
                    Provider=Microsoft.ACE.OLEDB.12.0;
                    Data Source={0};
                    Extended Properties=""Excel 12.0 Xml;HDR=YES""
                ",pathToExcel);
               
                //Creating and opening a data connection to the Excel sheet 
                using (var conn=new OleDbConnection(connectionString)) {
                    conn.Open();
    
                    var cmd=conn.CreateCommand();
                    cmd.CommandText = String.Format(
                        @"SELECT * FROM [{0}$]",
                        sheetName
                    );
    
                    using (var rdr=cmd.ExecuteReader()) {
    
                        //LINQ query - when executed will create anonymous objects for each row
                        var query =
                            from DbDataRecord row in rdr
                            select new {
                                name = row[0],
                                regno = row[1],
                                description = row[2]
                            };
    
                        //Generates JSON from the LINQ query
                        var json = JsonConvert.SerializeObject(query);
                        //Write the file to the destination path    
                        File.WriteAllText(destinationPath, json);
                    }
                }
            }
        }
    }
