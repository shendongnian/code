    try
    {
        var connectionInfo = // something
        using(var client = new SftpClient(connectionInfo))
        {
            client.Connect();
            using(var sftpFileStream = client.OpenRead(path))
            {
                // download the file
            }
        }
    }
