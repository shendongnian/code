    public static class SqlExtensions
    {
        public static bool IsAvailable(this SqlConnection connection)
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
