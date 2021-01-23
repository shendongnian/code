    public static class SqlExtensions
    {
        public static bool TestOpenConnection(this SqlConnection connection)
        {
            try
            {
                connection.Open();
                connection.Close();
            }
            catch(SqlException)
            {
                return false;
            }
        
            return true;
        }
    }
