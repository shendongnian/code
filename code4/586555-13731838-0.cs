    public T ExecuteQuery<T>(Func<IDataReader, T> getResult, string query, Dictionary<string, object> parameters)
    {
        using (SqlConnection conn = new SqlConnection(this.DefaultConnectionString))
        {
            conn.Open();
    
            // Declare the parameter in the query string
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
                command.Prepare();
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    return getResult(dr);
                }
            }
        }
    }
    
    public string GetMySpecId(string dataId)
    {
        return ExecuteQuery(
            dr =>
            {
                if (dr.Read())
                {
                    return dr[0].ToString();
                }
    
                return string.Empty;
            },
            "select \"specId\" from \"MyTable\" where \"dataId\" = @dataId",
            new Dictionary<string, object>() { { "@dataId", dataId } });
    }
