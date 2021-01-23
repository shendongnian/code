    class SqlHelper
    {
        public delegate void SqlCommandDelegate(SqlCommand command);
    
        public Dataset ExecuteDataset(string dsn, 
                CommandType commandType, 
                SqlCommandDelegate specificPreparations)
        {
            Dataset results;
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = dsn;
                using (SqlCommand command = conn.CreateCommand())
                {
                    command.CommandType = commandType;
                    connection.Open();
                    specificPreparations(command);
                    SqlDataReader reader = command.ExecuteReader();
                    results.Load(reader);
                }
            }
            
            return results;
        }
    }
