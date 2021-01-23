    /// <summary>
    /// This sample will list the contents of the current directory.
    /// </summary>
    public void ListDirectory()
    {
        string host            = "";
        string username        = "";
        string password        = "";
        string remoteDirectory = "."; // . always refers to the current directory.
        
        using (var sftp = new SftpClient(host, username, password))
        {
            var files = sftp.ListDirectory(remoteDirectory);
            foreach (var file in files)
            {
                Console.WriteLine(file.FullName);
            }
        }
    }
