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
                string myConnectionString;
                myConnectionString =
                        @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                        @"Data Source=C:\Users\Public\Database1.accdb;";
                using (var con = new OleDbConnection())
                {
                    con.ConnectionString = myConnectionString;
                    con.Open();
                    using (var cmd = new OleDbCommand())
                    {
                        // just to be sure, let's force one of the values to Null
                        cmd.Connection = con;
                        cmd.CommandText =
                                "UPDATE YesNoTable SET YesNoField = NULL " +
                                "WHERE Description = 'Null'";
                        cmd.ExecuteNonQuery();
                    }
                    using (var cmd = new OleDbCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText =
                                "SELECT ID, YesNoField, Description FROM YesNoTable";
                        OleDbDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            Console.WriteLine(String.Format("Row {0}:", rdr["ID"]));
                            bool boolValue = Convert.ToBoolean(rdr["YesNoField"]);
                            Console.WriteLine(String.Format("    Description is: {0}", rdr["Description"]));
                            Console.WriteLine(String.Format("    Return type is: {0}", rdr["YesNoField"].GetType()));
                            Console.WriteLine(String.Format("    raw value is: {0}", rdr["YesNoField"]));
                            Console.WriteLine(String.Format("    boolValue is: {0}", boolValue));
                            Console.WriteLine();
                        }
                    }
                    con.Close();
                }
                Console.WriteLine("Done.");
            }
        }
    }
