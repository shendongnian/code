    class SomeClass
    {
        private void button1_Click(object sender, EventArgs e)
        {
            using (var conn = Utilities.GetConnection())
            {
                conn.Open();
                // Code
            }
        }
    }
    public static class Utilities
    {
        public static MySqlConnection GetConnection()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "Connection";
            return conn;
        }
    }
