        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection("Some SQLConnectionString")) {
            conn.Open();
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT TOP 0 * FROM SomeTable", conn))
            {
                adapter.Fill(dt);
            };
        };
