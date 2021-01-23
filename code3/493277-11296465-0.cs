            using (var Conn = new SqlConnection(ConnectString))
            {
                Conn.Open();
                try
                {
                    using (var cmd = new SqlCommand("THEPROCEDUREQUERY", Conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader reader = cmd.ExecuteReader();
                        // Find Id of column in query only once at start
                        var Col1IdOrd = reader.GetOrdinal("ColumnName");
                        var Col2IdOrd = reader.GetOrdinal("ColumnName");
                        // loop through all the rows
                        while (reader.Read())
                        {
                            // get data for each row
                            var Col1 = reader.GetInt32(ColIdOrd);
                            var Col2 = reader.GetDouble(Col2IdOrd);
                            // Do something with data from one row for both columns here
                        }
                    }
                }
                finally
                {
                    Conn.Close();
                }
