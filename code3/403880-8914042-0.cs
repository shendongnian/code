    public static DataSet UpdateSqlRows(
        string connectionString, 
        string selectQuery,
        string insertQuery,
        string updateQuery,
        string deleteQuery,
        DataSet dataSet)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                adapter.SelectCommand = new SqlCommand(selectQuery, connection);
    
                connection.Open();
    
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
    
                // Assign your own Insert/Update/Delete commands
                adapter.InsertCommand = new SqlCommand( insertQuery );
                adapter.UpdateCommand = new SqlCommand( updateQuery );
                adapter.DeleteCommand = new SqlCommand( deleteQuery );
    
                //Without the SqlCommandBuilder this line would fail
                adapter.Update(dataSet);
    
                return dataSet;
            }
        }
    }
