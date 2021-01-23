    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.OleDb;
    
    namespace oleDbTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var con = new OleDbConnection(
                            "Provider=Microsoft.ACE.OLEDB.12.0;" +
                            @"Data Source=C:\__tmp\main.accdb;"))
                {
                    con.Open();
                    using (var cmd = new OleDbCommand(
                                "SELECT TOP 1 [Date] FROM [Events]", con))
                    {
                        string time_stmp =  Convert.ToDateTime(cmd.ExecuteScalar()).ToString("yyyyMMdd");
                        Console.WriteLine(time_stmp.ToString());
                    }
                    con.Close();
                }
                Console.WriteLine("Done.");
                System.Threading.Thread.Sleep(2000);
            }
        }
    }
