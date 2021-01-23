    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.OleDb;
    using System.Data;
    
        namespace ConsoleApplication1
        {
            class Program
            {
                static void Main(string[] args)
                {
                    OleDbConnection connection = new OleDbConnection(
            "Provider=VFPOLEDB.1;Data Source=F:\\Gutters\\Data\\database.dbc;"
        );
                    connection.Open();
                    DataTable tables = connection.GetSchema(
                        System.Data.OleDb.OleDbMetaDataCollectionNames.Tables
                    );
        
                    foreach (System.Data.DataRow rowTables in tables.Rows)
                    {
                        Console.Out.WriteLine(rowTables["table_name"].ToString());
                        DataTable columns = connection.GetSchema(
                            System.Data.OleDb.OleDbMetaDataCollectionNames.Columns,
                            new String[] { null, null, rowTables["table_name"].ToString(), null }
                        );
                        foreach (System.Data.DataRow rowColumns in columns.Rows)
                        {
                            Console.Out.WriteLine(
                                rowTables["table_name"].ToString() + "." +
                                rowColumns["column_name"].ToString() + " = " +
                                rowColumns["data_type"].ToString()
                            );
                        }
                    }
        
                    string sql = "select * from customer";
                    OleDbCommand cmd = new OleDbCommand(sql, connection);
        
                    DataTable YourResultSet = new DataTable();
                    OleDbDataAdapter DA = new OleDbDataAdapter(cmd);
                    
                    DA.Fill(YourResultSet);
                }
            }
        }
