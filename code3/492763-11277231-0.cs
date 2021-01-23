    using (var con = new SqlConnection(Properties.Settings.Default.ConnectionString))
    using (var cmd = new SqlCommand("SELECT * FROM TABLE ORDER BY COLUMN", con))
    {
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
