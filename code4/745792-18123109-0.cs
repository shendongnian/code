    using (var con = new SqlConnection(Properties.Settings.Default.ConnectionString))
    {
        using (var cmd = new SqlCommand("SELECT * FROM TableA; SELECT * FROM TableB; SELECT * FROM TableC;", con))
        {
            con.Open();
            using (IDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    int firstIntCol = rdr.GetInt32(0); // assuming the first column is of type Int32
                    // other fields ...
                }
                if (rdr.NextResult())
                {
                    while (rdr.Read())
                    {
                        int firstIntCol = rdr.GetInt32(0); // assuming the first column is of type Int32
                        // other fields ...
                    }
                    if (rdr.NextResult())
                    {
                        while (rdr.Read())
                        {
                            int firstIntCol = rdr.GetInt32(0); // assuming the first column is of type Int32
                            // other fields ...
                        }
                    }
                }
            }
        }
    }
