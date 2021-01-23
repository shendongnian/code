        private static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["c1"].ToString());
        }
        private void Method1()
        {
            using (var conn = GetSqlConnection())
            {
                conn.Open();
                // do stuff...
            }
        }
        private void Method2()
        {
            using (var conn = GetSqlConnection())
            {
                conn.Open();
                // do other stuff...
            }
        }
