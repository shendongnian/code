        public void BackUpData(string file)
        {
            using (MySqlConnection con = new MySqlConnection { ConnectionString = config })
            {
                using (MySqlCommand cmd = new MySqlCommand { Connection = con })
                {
                    using (MySqlBackup mb = new MySqlBackup { Command = cmd })
                    {
                        try
                        {
                            con.Open();
                            try
                            {
                                mb.ExportToFile(file);
                            }
                            catch(MySqlException ex)
                            {
                                msgErr(ex.Message + " sql query error.");
                                return;
                            }
                        }
                        catch(MySqlException ex)
                        {
                            msgErr(ex.Message + " connection error.");
                            return;
                        }
                        
                        
                    }
                }
            }
        }
