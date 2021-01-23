    using (FTPConnection ftp = new FTPConnection())
    {
        ftpConnection.ServerAddress = "myserver";
        ftpConnection.UserName = userName;
        ftpConnection.Password = password; 
        ftpConnection.Connect();
        ftpConnection.DownloadFile(localFilePath, remoteFileName);
    }
