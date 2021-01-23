    internal class CommonData
      {
        private static SqlConnection conn;
        public static SqlConnection Connection
        {
            get { return conn; }
        }
        public static void ReadyConnection()
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
        }
        public static int ExecuteNonQuery(SqlCommand command)
        {
            try
            {
                ReadyConnection();
                command.Connection = conn;
                int result = command.ExecuteNonQuery();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Dispose();
                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Dispose();
            }
        }
        public static SqlDataReader ExecuteReader(SqlCommand command)
        {
            try
            {
                ReadyConnection();
                command.Connection = conn;
                SqlDataReader result = command.ExecuteReader(CommandBehavior.CloseConnection);
                return result;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public static object ExecuteScalar(SqlCommand command)
        {
            try
            {
                ReadyConnection();
                command.Connection = conn;
                object value = command.ExecuteScalar();
                if (value is DBNull)
                {
                    return default(decimal);
                }
                else
                {
                    return value;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void ClearPool()
        {
            SqlConnection.ClearAllPools();
        }
    }
