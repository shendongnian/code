    public void Backup()
        {
            try
            {
                // Backup...
                DateTime Time = DateTime.Now;
                year = Time.Year;
                month = Time.Month;
                day = Time.Day;
                hour = Time.Hour;
                minute = Time.Minute;
                second = Time.Second;
                millisecond = Time.Millisecond;
                //Save file to Path with the current date as a filename
                string path;
                path = txb_Path.Text + year + "-" + month + "-" + day + "--" + hour + "-" + minute + "-" + second + ".sql";
                string file = path;
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ExportToFile(file);
                            conn.Close();
                        }
                    }
                }
                //Done----
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error , unable to backup!" + ex.Message);
            }
        }
