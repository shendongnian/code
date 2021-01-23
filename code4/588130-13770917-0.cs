    public Code GetByCode(string value)
    {
        // Go to DB and find code. Just using a sample.
        // assuming SqlConnection, store the connection-string f.e. in the settings
        string sql = "SELECT Columns FROM dbo.Table Where Value=@Value";
        using(var con = new SqlConmection(connectionString))
        using(var cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@Value", value);
            con.open();
            using(var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Code code = new Code();
                    // initiliaze it from the reader, f.e.
                    code.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                }
            }
        }
    }
`
