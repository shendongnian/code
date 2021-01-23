       static void Main(string[] args)
        {
            ExecWithType(CommandType.Text);
            ExecWithType(CommandType.StoredProcedure);
        }
        static void ExecWithType(CommandType type)
        {
            using (SqlConnection conn = new SqlConnection(Settings.Default.connString))
            {
                conn.Open();
                using (SqlCommand cmd1 = new SqlCommand("usp_test", conn))
                {
                    cmd1.CommandType = type;
                    cmd1.Parameters.AddWithValue("@p1", "bar");
                    cmd1.Parameters.AddWithValue("@p2", 24);
                    using (SqlDataReader rdr = cmd1.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Console.WriteLine("Type: {0} Result: @p1: {1} @p2: {2}", type, rdr[0], rdr[1]);
                        }
                    }
                }
            }
        }
