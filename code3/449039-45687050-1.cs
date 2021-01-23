    // Setup session options
    SessionOptions sessionOptions = new SessionOptions
    {
        Protocol = Protocol.Ftp,
        HostName = "ftp.example.com",
        UserName = "username",
        Password = "password",
    };
    using (Session session = new Session())
    {
        // Connect
        session.Open(sessionOptions);
        // Download files modified with the last hour
        TransferOptions transferOptions = new TransferOptions();
        transferOptions.FileMask = "*>=1H";
        session.GetFiles("/remote/path/*", @"C:\local\path\", false, transferOptions).Check();
    }
