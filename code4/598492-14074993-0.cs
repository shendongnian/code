        public  MySqlConnection conncting()
        {
            MySqlConnection connection;
            string cs = @"server=localhost;userid=root;password=;database=taxi";
            connection = new MySqlConnection(cs);
            try
            {
                connection.Open();
                return connection;
            }
            catch (MySqlException ex)
            {
                return null;
               // MessageBox.Show(ex.ToString());
            }
        }
 
