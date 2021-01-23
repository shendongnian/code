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
                string myConnectionStringMDB =
                        "Provider=Microsoft.ACE.OLEDB.12.0;" +
                        @"Data Source=C:\Users\Gord\Desktop\fromCE.mdb;";
                string myConnectionStringSQL =
                        "Provider=Microsoft.SQLSERVER.CE.OLEDB.3.5;" +
                        @"Data Source=C:\__tmp\myData.sdf;";
                using (OleDbConnection conSQL = new OleDbConnection(), 
                        conMDB = new OleDbConnection())
                {
                    conSQL.ConnectionString = myConnectionStringSQL;
                    conSQL.Open();
                    conMDB.ConnectionString = myConnectionStringMDB;
                    conMDB.Open();
                    using (OleDbCommand cmdSQL = new OleDbCommand(), 
                            cmdMDB = new OleDbCommand())
                    {
                        cmdSQL.CommandType = System.Data.CommandType.Text;
                        cmdSQL.Connection = conSQL;
                        cmdSQL.CommandText = "SELECT * FROM [Table1]";
                        var daSQL = new System.Data.OleDb.OleDbDataAdapter();
                        daSQL.SelectCommand = cmdSQL;
                        var dtSQL = new System.Data.DataTable();
                        daSQL.Fill(dtSQL);
                        System.Data.DataTable dtMDB = dtSQL.Clone();
                        
                        foreach (System.Data.DataRow drSQL in dtSQL.Rows)
                        {
                            // .ImportRow() would import the row as "Unchanged", so create a new one
                            System.Data.DataRow drMDB = dtMDB.NewRow();
                            drMDB.ItemArray = drSQL.ItemArray;
                            dtMDB.Rows.Add(drMDB);
                        }
                        cmdMDB.CommandType = System.Data.CommandType.Text;
                        cmdMDB.Connection = conMDB;
                        cmdMDB.CommandText = "INSERT INTO [Table1] ([ID], [Field 1]) VALUES (?, ?)";
                        cmdMDB.Parameters.Add("?", OleDbType.Integer, 1, "ID");
                        cmdMDB.Parameters.Add("?", OleDbType.VarWChar, 255, "Field 1");
                        var daMDB = new System.Data.OleDb.OleDbDataAdapter();
                        daMDB.InsertCommand = cmdMDB;
                        daMDB.Update(dtMDB);
                    }
                    conSQL.Close();
                    conMDB.Close();
                }
                Console.WriteLine("Done.");
                System.Threading.Thread.Sleep(2000);
            }
        }
    }
