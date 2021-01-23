    public static int ExecStoredProcWithTVP(DbConnection connection, string storedProcedureName, string tableName, string tableTypeName, DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(storedProcedureName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
    
                SqlParameter p = cmd.Parameters.AddWithValue(tableName, dt);
                p.SqlDbType = SqlDbType.Structured;
                p.TypeName = tableTypeName;
    
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery(); // or could execute reader and pass a Func<T> to perform action on the datareader;
                conn.Close();
    
                return rowsAffected;
            }
        }
