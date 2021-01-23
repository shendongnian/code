    public delegate void SqlCOmmandDelegate(SqlCommand command);
    
    public class Dal
    {
        public void ExecuteStoredProcedure(string procedureName, 
            SqlCommandDelgate commandDelegate)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = GetConnectionString();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = procedureName;
                    connection.Open();
                    commandDelegate(command);
                }
            }
        }
    }
    
    class UsesDal
    {
        public CallFirstProcedure(int value)
        {
            string userName;
    
            ExecuteStoredProcedure("FIRST_PROCEDURE",
                delegate(SqlCommand command)
                {
                    command.Parameters.Add("UserID", value);
                    command.ExecuteReader();
    
                    //Do stuff with results e.g.
                    username = command.Parameters.Parameters["UserName"].ToString();
                }
        }
    
        public CallOtherProcedure(string value)
        {
            int id;
            ExecuteStoredProcedure("OTHER_PROCEDURE",
                delegate(SqlCommand command)
                {
                    command.Parameters.Add("ParameterName", value);
                    id = command.ExecuteScalar();
                }
        }
    }
