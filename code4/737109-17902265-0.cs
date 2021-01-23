    userInfo = searchBox.Text;
            MySqlConnection connection = null;
            string query = "SELECT * FROM " + userInfo + " ORDER BY date DESC;";
            userGrid.Rows.Clear(); 
            using (connection = new MySqlConnection(Hash.RunDecryption()))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    userGrid.DataSource = null;
                    DataSet dt = new DataSet();
                    MySqlDataAdapter da = new MySqlDataAdapter(command);
                    da.Fill(dt);
                    userGrid.DataSource = dt.Tables[0];
                    connection.Close();
                }
            }
