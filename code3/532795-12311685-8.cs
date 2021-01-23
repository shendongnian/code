    private void Backup()
    {
        string constring = "server=localhost;user=root;pwd=qwerty;database=test;";
        string file = "C:\\backup.sql";
        using (MySqlConnection conn = new MySqlConnection(constring))
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
    }
