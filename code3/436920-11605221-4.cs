    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Web;
    
    public class SqlComm
    {
    	// this is a shortcut for your connection string
    	static string DatabaseConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["dbConStr"].ConnectionString;
    
    	// this is for just executing sql command with no value to return
        public static void SqlExecute(string sql)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    
	// with this you will be able to return a value
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
    	// with this you can retrieve an entire table or part of it
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
    	
	// sooner or later you will probably use stored procedures. 
	// you can use this in order to execute a stored procedure with 1 parameter
	// it will work for returning a value or just executing with no returns
    	public static object SqlStoredProcedure1Param(string StoredProcedure, string PrmName1, object Param1)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseConnectionString))
            {
                SqlCommand cmd = new SqlCommand(StoredProcedure, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter(PrmName1, Param1.ToString()));
                cmd.Connection.Open();
                object obj = new object();
                obj = cmd.ExecuteScalar();
                return obj;
            }
        }
    }
