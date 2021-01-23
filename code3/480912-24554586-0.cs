     using (var sftp = new SftpClient(host, username, password))
            {
                try
                {
                    sftp.Connect();
                    MessageBox.Show(sftp.Exists(remoteDirectory).ToString());
                }
                catch (Exception Sftpex)
                {
                    MessageBox.Show(Sftpex.ToString());
                }
            }
