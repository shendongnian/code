    /// <summary>
    /// This sample will upload a file on your local machine to the remote system.
    /// </summary>
    public void UploadFile()
    {
        string host           = "";
        string username       = "";
        string password       = "";
        string localFileName  = "";
        string remoteFileName = System.IO.Path.GetFileName(localFile);
    
        using (var sftp = new SftpClient(host, username, password))
        {
            sftp.Connect();
    
            using (var file = File.OpenRead(localFileName))
            {
                sftp.UploadFile(remoteFileName, file);
            }
    
            sftp.Disconnect();
        }
    }
