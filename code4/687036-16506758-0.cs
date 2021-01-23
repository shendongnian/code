    _connectionStr = new MySqlConnectionStringBuilder
                {
                    Server = "127.0.0.1",
                    Database = myDatabase,
                    UserID = myUserName,
                    Password = myPassword,
                    ConnectionTimeout=60,
                    Port = 3306,
                    AllowZeroDateTime = true
                };
                _con = new MySqlConnection(_connectionStr.ConnectionString);
    
                try
                {
                    _con.Open();
                }
                catch
                {
                    MessageBox.Show("Error, help i can't get connected!");
                }
