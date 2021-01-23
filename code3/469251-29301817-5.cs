    /// <summary>
    /// This sample will download a file on the remote system to your local machine.
    /// </summary>
    public void DownloadFile()
    {
        string host           = "";
        string username       = "";
        string password       = "";
        string localFileName  = System.IO.Path.GetFileName(localFile);
        string remoteFileName = "";
    
        using (var sftp = new SftpClient(host, username, password))
        {
            sftp.Connect();
    
            using (var file = File.OpenWrite(localFileName))
            {
                sftp.DownloadFile(remoteFileName, file);
            }
    
            sftp.Disconnect();
        }
    }
