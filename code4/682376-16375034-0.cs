               DataTable table = new DataTable();
                NpgsqlConnection conn = new NpgsqlConnection(dataConnection.getConnection());
                conn.Open();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter();
                NpgsqlCommand command = new NpgsqlCommand("SELECT tavlingsID, titel FROM tavlingar WHERE datum > @datum ORDER BY titel ASC;", conn);
                command.Parameters.AddWithValue("@datum", strDate);
                da.SelectCommand = command;
                da.Fill(table);
