        public MySqlConnection conncting()
        {
            string cs = @"server=localhost;userid=root;password=;database=taxi";
            MySqlConnection connection = new MySqlConnection(cs);
            connection.Open();
            return connection;
        }
