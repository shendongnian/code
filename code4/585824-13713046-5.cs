    public T ExecuteQuery<T>(
        Func<IDataReader, T> getResult,
        string query,
        params IDataParameter[] parameters)
    {
        using (SqlConnection conn = new SqlConnection(this.MyConnectionString))
        {
            conn.Open();
            // Declare the parameter in the query string
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                foreach(var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
                command.Prepare();
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    return getResult(dr);
                }
            }
        }
    }
