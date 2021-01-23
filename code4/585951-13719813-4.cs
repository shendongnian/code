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
    
                //Use this connection string if you have Office 2007+ drivers installed and 
                //your data is saved in a .xlsx file
                var connectionString = $@"
                    Provider=Microsoft.ACE.OLEDB.12.0;
                    Data Source={pathToExcel};
                    Extended Properties=""Excel 12.0 Xml;HDR=YES""
                ";
                //Creating and opening a data connection to the Excel sheet 
                using (var conn=new OleDbConnection(connectionString)) {
                    conn.Open();
    
                    var cmd=conn.CreateCommand();
                    cmd.CommandText = $"SELECT * FROM [{sheetName}$]";
    
                    using (var rdr=cmd.ExecuteReader()) {
    
                        //LINQ query - when executed will create anonymous objects for each row
                        var query = rdr.Cast<DbDataRecord>().Select(row => new {
                            name = row[0],
                            regno = row[1],
                            description = row[2]
                        });
                        //Generates JSON from the LINQ query
                        var json = JsonConvert.SerializeObject(query);
                        //Write the file to the destination path    
                        File.WriteAllText(destinationPath, json);
                    }
                }
            }
        }
    }
