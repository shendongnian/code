    public static calss Utilities
    {
        public static bool SQLResult(SqlConnection conn, string strSQL)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = strSQL;
                strResult = cmd.ExecuteScalar().ToString();
            }
            catch (Exception e)
            {
                // Return error or display.
                return false;
            }
            return true;
        }
    }
