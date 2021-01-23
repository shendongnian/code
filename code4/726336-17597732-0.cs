    public void ExecuteQuery(string query, Dictionary<string, object> parameters)
    {
    using (SqlConnection conn = new SqlConnection(this.connectionString))
    {
        conn.Open();
        using (SqlCommand cmd = conn.CreateCommand())
        {
            cmd.CommandText = query;
            if (parameters != null)
            {
                foreach (string parameter in parameters.Keys)
                {
                    cmd.Parameters.AddWithValue(parameter, parameters[parameter]);
                }
            }
            cmd.ExecuteNonQuery();
        }
    }
    }
