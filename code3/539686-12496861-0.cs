    var ftpClient = new Mock<IFTPClient<object, object>>();
    using (var ftpServer = new FTPServerConnection<object, object>(
         ftpClient.Object,
         "1.2.3.4",
         "user",
         "passwd"))
    {
        ftpServer.Connect();
    }
