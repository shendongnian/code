            public bool Login(string username, string password)
            {
                DataTable dt = new DataTable();
                string config = "server=....";
                using (var con = new MySqlConnection { ConnectionString = config })
                {
                    using (var command = new MySqlCommand { Connection = con })
                    {
                        con.Open();
                        command.CommandText = @"SELECT * FROM login WHERE username=@username AND password=@password";
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);
                        dt.Load(command.ExecuteReader());
                        if (dt.Rows.Count > 0)
                            return true;
                        else
                            return false;
    
                    } // Close and Dispose command
                } // Close and Dispose connection
            }
