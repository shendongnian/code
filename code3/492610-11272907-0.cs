    string sql = "SELECT city FROM glmast WHERE glname = @glname";
    using (var conn = new SqlConnection("Some connection string"))
    using (var cmd = conn.CreateCommand())
    {
        conn.Open();
        cmd.Parameters.AddWithValue("@glname", list_customer.Items[i].Value);
        using (var reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                // do something with the results
            }
        }
    }
