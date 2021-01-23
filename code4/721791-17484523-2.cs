    private void button_backup_Click(object sender, EventArgs e)
            {
                //con is the connection string
                con.Open();
                string str = "USE TestDB;";
                string str1="BACKUP DATABASE TestDB TO DISK = 'E:\\backupfile.Bak' WITH FORMAT,MEDIANAME = 'Z_SQLServerBackups',NAME = 'Full Backup of Testdb';";
                SqlCommand cmd1 = new SqlCommand(str, con);
                SqlCommand cmd2 = new SqlCommand(str1, con);
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                MessageBox.Show("success");
                con.Close();
            }
