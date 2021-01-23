    public class DbConnection
    {
        public static DbCommandToken db_Update_Delete_Query(string strQuery)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(strConnectionString))
                {
                    connection.Open();
                    var transaction = connection.BeginTransaction();
                    SqlCommand command = new SqlCommand(strQuery, connection);
                    return new DbCommandToken(transaction, command);
                }
            }
            catch (Exception)
            {
                //some error handling.
            }
        }
    }
