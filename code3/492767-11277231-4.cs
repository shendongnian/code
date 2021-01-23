    // use using statements to ensure that connections are disposed/closed (all implementing IDisposable)
    using (var con = new SqlConnection(Properties.Settings.Default.ConnectionString))
    using (var cmd = new SqlCommand("SELECT email, name FROM mytable WHERE id=@id", con))
    {
        cmd.Parameters.AddWithValue("@id", ID);  // use parameters to avoid sql-injection
        con.Open();
        using (var reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            { 
                var fields = new object[reader.FieldCount];
                // following fills an object[] with all fields of the current line, 
                // is this similar to mysql_fetch_array?
                int count  = reader.GetValues(fields);
            }
        }
    }
