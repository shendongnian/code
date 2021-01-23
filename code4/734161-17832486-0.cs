    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.SqlClient;
    using System.Data;
    namespace SQLCommandBuilder
    {
        class Program
        {
            static void Main(string[] args)
            {
                SqlConnectionStringBuilder ConnStringBuilder = new SqlConnectionStringBuilder();
                ConnStringBuilder.DataSource = @"(local)\SQLEXPRESS";
                ConnStringBuilder.InitialCatalog = "TestUndSpiel";
                ConnStringBuilder.IntegratedSecurity = true;
                SqlConnection sqlConn = new SqlConnection(ConnStringBuilder.ConnectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(string.Format("SELECT * FROM {0}", "ice_provinces"), sqlConn);
                adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;   // needs to be set to apply table schema from db to datatable
                using (new SqlCommandBuilder(adapter))
                {
                    try
                    {
                        DataTable dtPrimary = new DataTable();                                   
                        adapter.Fill(dtPrimary);
                        // this yould be a record you identified as to update:
                        dtPrimary.Rows[1]["pv_name"] = "value";
                                        
                        sqlConn.Open();
                        adapter.Update(dtPrimary);
                        sqlConn.Close();
                    }
                    catch (Exception es)
                    {
                        Console.WriteLine(es.Message);
                        Console.Read();
                    }
                }
            }
        }
    }
