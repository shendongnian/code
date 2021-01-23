    // Assumes parameter names @0, @1, @2 ... in the query.
    public static T ExecuteScalar<T>(string query, params object[] parameters)
    {
        using(var conn = new SqlConnection(myConnectionString))
        using (var cmd = new SqlCommand(query, conn)) {
            for (int i = 0; i < parameters.Length; i++) {
                cmd.Parameters.AddWithValue("@" + i, parameters[i]);
            }
            conn.Open();
            return (T)cmd.ExecuteScalar();
        }
    }
