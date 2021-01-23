    private void button_backup_Click(object sender, EventArgs e)<br/>
            {<br/>
                //con is the connection string<br/>
                con.Open();<br/>
                string str = "USE TestDB;";<br/>
                string str1="BACKUP DATABASE TestDB TO DISK = 'E:\\backupfile.Bak' WITH FORMAT,MEDIANAME = 'Z_SQLServerBackups',NAME = 'Full Backup of Testdb';";<br/>
                SqlCommand cmd1 = new SqlCommand(str, con);<br/>
                SqlCommand cmd2 = new SqlCommand(str1, con);<br/>
                cmd1.ExecuteNonQuery();<br/>
                cmd2.ExecuteNonQuery();<br/>
                MessageBox.Show("success");<br/>
                con.Close();<br/>
            }
