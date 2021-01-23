    try
    {
        var connectionInfo = // something
        using(var client = new SftpClient(connectionInfo))
        {
            client.Connect();
            using(var streamArquivoSftp = servidorSFTP.OpenRead(path))
            {
                // download the file
            }
        }
    }
