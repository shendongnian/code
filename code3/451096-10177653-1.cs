    using Renci.SshNet;
    using Renci.SshNet.Sftp;
    public void DeleteFile(string server, int port, string username, string password, string sftpPath)
    {
        using (SftpClient sftpClient = new SftpClient(server, port, username, password))
        {
            sftpClient.Connect();
            sftpClient.DeleteFile(sftpPath);
            sftpClient.Disconnect();
        }
    }
