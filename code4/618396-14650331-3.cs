    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Data;
    using System.Data.SqlClient;
    public class SqlComm
    {
       static string DatabaseConnectionString = "your connection string";
       public static object SqlReturn(string sql)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);                  
                object result = (object)cmd.ExecuteScalar();
                return result;           
           
            }
        }
       public static DataTable SqlDataTable(string sql)
       {
           using (SqlConnection conn = new SqlConnection(DatabaseConnectionString))
           {
               SqlCommand cmd = new SqlCommand(sql, conn);
               cmd.Connection.Open();
               DataTable TempTable = new DataTable();
               TempTable.Load(cmd.ExecuteReader());
               return TempTable;
           }
    }
