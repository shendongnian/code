            ListBox lb = new ListBox();
            string connectionString = "your connection string here";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT column FROM myitemstable";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) {
                            lb.Items.Add(new ListItem((string)reader["column"]));
                        }
                    }
                }
            }
