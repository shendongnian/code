    using System;
    using System.IO;
    using System.Data;
    using System.Data.Odbc;
    using System.Data.OleDb;
    using System.Data.Common;
    
    namespace VFPExample
    {
        class VFPExample
        {
            /*
             * http://stackoverflow.com/questions/754436/odbc-dbf-files-in-c-sharp/
             * http://www.devnewsgroups.net/group/microsoft.public.dotnet.framework/topic62548.aspx
             */
            static void Main(String[] args)
            {
                try
                {
                    string strTestDirectory = @"Provider=VFPOLEDB.1; Data Source=D:\TEMP\";
    
                    using (OleDbConnection vfpro_con_insert = new OleDbConnection(strTestDirectory) )
                    {
                        vfpro_con_insert.Open(); 
    
                        OleDbCommand createTable = new OleDbCommand(@"Create Table TestDBF (Field1 N(2,0), Field2 C(10))", vfpro_con_insert);
                        OleDbCommand insertTable1 = new OleDbCommand(@"Insert Into TestDBF (Field1, Field2) Values (1, 'Hello')", vfpro_con_insert);
                        OleDbCommand insertTable2 = new OleDbCommand(@"Insert Into TestDBF (Field1, Field2) Values (2, 'World')", vfpro_con_insert);
    
                        createTable.ExecuteNonQuery();
                        insertTable1.ExecuteNonQuery();
                        insertTable2.ExecuteNonQuery();
    
                        Console.WriteLine("Wrote in " + vfpro_con_insert.DataSource);
                    }
    
                    Console.ReadLine();
    
                    using (OleDbConnection vfpro_con_read = new OleDbConnection(strTestDirectory))
                    {
                        Console.WriteLine("Read from " + vfpro_con_read.DataSource);
    			
                        vfpro_con_read.Open();
    
                        OleDbCommand readTable = new OleDbCommand(@"Select * From TestDBF", vfpro_con_read);
    
                        OleDbDataAdapter da = new OleDbDataAdapter(readTable);
    
                        DataSet ds = new DataSet();
    
                        da.Fill(ds);
    
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            Console.WriteLine(dr.ItemArray[1].ToString());
                        }
                    }
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine("\n\n Exception:\n\n{0}", e.Message); // Set Breakpoint here for detailed StackTrace
                }
            }
        }
    }
