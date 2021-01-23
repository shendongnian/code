    string role;
    using(SqlConnection conn = new SqlConnection(var3))
    using(SqlCommand cmd = new SqlCommand("Decryptpaswd", conn))
    {
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("Username", username);
        cmd.Parameters.AddWithValue("Pasword", password);
        conn.Open();
        query = (string)cmd.ExecuteScalar();
    }
    switch(role) {
       ...
    }
