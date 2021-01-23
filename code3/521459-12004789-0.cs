    string query;
    using(SqlConnection conn = new SqlConnection(var3))
    using(SqlCommand cmd = new SqlCommand("Decryptpaswd", conn))
    {
        cmd.CommandType = CommandType.StoredProcedure;
        conn.Open();
        query = (string)cmd.ExecuteScalar();
    }
    switch(query) {
       ...
    }
