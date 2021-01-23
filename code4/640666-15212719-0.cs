    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlServerCe;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace SQLCESearch
    {
        class Program
        {
            static void Main(string[] args)
            {
                SearchText("Nancy");
                Console.ReadKey();
            }
    
            private static void SearchText(string searchText)
            {
                string connStr = "Data Source=Northwind40.sdf;Persist Security Info=False;";
                DataTable dt = new DataTable();
                try
                {
                    string sql = "SELECT c.TABLE_NAME, c.COLUMN_NAME ";
                    sql += "FROM   INFORMATION_SCHEMA.COLUMNS AS c ";
                    sql += "INNER JOIN INFORMATION_SCHEMA.Tables AS t ON t.TABLE_NAME = c.TABLE_NAME ";
                    sql += "WHERE  (c.DATA_TYPE IN ('char', 'nchar', 'varchar', 'nvarchar', 'text', 'ntext')) AND (t.TABLE_TYPE = 'TABLE') ";
    
                    SqlCeDataAdapter da = new SqlCeDataAdapter(sql, connStr);
                    da.Fill(dt);
    
                    foreach (DataRow dr in dt.Rows)
                    {
                        string dynSQL = "SELECT [" + dr["COLUMN_NAME"] + "]";
                        dynSQL += " FROM [" + dr["TABLE_NAME"] + "]";
                        dynSQL += " WHERE [" + dr["COLUMN_NAME"] + "] LIKE '%" + searchText + "%'";
    
                        DataTable result = new DataTable();
                        da = new SqlCeDataAdapter(dynSQL, connStr);
                        da.Fill(result);
                        foreach (DataRow r in result.Rows)
                        {
                            Console.WriteLine("Table Name: " + dr["TABLE_NAME"]);
                            Console.WriteLine("Column Name: " + dr["COLUMN_NAME"]);
                            Console.WriteLine("Value: " + r[0]);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }
    
    
            }
        }
    }
