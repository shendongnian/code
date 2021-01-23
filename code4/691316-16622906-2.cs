    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.OleDb;
    
    namespace oledbTest1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\__tmp\testData.accdb;");
                conn.Open();
                var cmd = new OleDbCommand(
                        "SELECT Table1.ProductType, SUM(Table1.ProductsSold) AS TotalSold " +
                        "FROM Table1 " +
                        "WHERE Table1.DateTime BETWEEN @StartDate AND @StopDate " +
                        "GROUP BY Table1.ProductType", 
                        conn);
                cmd.Parameters.AddWithValue("@StartDate", new DateTime(2013, 5, 16));
                cmd.Parameters.AddWithValue("@StopDate", new DateTime(2013, 5, 17));
                OleDbDataReader rdr = cmd.ExecuteReader();
                int rowCount = 0;
                while (rdr.Read())
                {
                    rowCount++;
                    Console.WriteLine("Row " + rowCount.ToString() + ":");
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        string colName = rdr.GetName(i);
                        Console.WriteLine("  " + colName + ": " + rdr[colName].ToString());
                    }
                }
                rdr.Close();
                conn.Close();
    
                Console.WriteLine("Done.");
                Console.ReadKey();
            }
        }
    }
