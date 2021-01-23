        //Secure FTP
        public void SecureFTPUploadFile(string destinationHost,int port,string username,string password,string source,string destination)
        {
            ConnectionInfo ConnNfo = new ConnectionInfo(destinationHost, port, username, new PasswordAuthenticationMethod(username, password));
            var temp = destination.Split('/');
            string destinationFileName = temp[temp.Count() - 1];
            string parentDirectory = destination.Remove(destination.Length - (destinationFileName.Length + 1), destinationFileName.Length + 1);
            using (var sshclient = new SshClient(ConnNfo))
            {
                sshclient.Connect();
                using (var cmd = sshclient.CreateCommand("mkdir -p " + parentDirectory + " && chmod +rw " + parentDirectory))
                {
                    cmd.Execute();
                }
                sshclient.Disconnect();
            }
            using (var sftp = new SftpClient(ConnNfo))
            {
                sftp.Connect();
                sftp.ChangeDirectory(parentDirectory);
                using (var uplfileStream = System.IO.File.OpenRead(source))
                {
                    sftp.UploadFile(uplfileStream, destinationFileName, true);
                }
                sftp.Disconnect();
            }
        }
