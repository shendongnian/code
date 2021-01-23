    using System;
    using WinSCP;
     
    class Example
    {
        public static int Main()
        {
            try
            {
                // Setup session options
                SessionOptions sessionOptions = new SessionOptions
                {
                    Protocol = Protocol.Sftp,
                    HostName = "example.com",
                    UserName = "user",
                    Password = "mypassword",
                    SshHostKeyFingerprint = "ssh-rsa 2048 xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx"
                };
     
                using (Session session = new Session())
                {
                    // Connect
                    session.Open(sessionOptions);
     
                    // Upload files
                    TransferOptions transferOptions = new TransferOptions();
                    transferOptions.TransferMode = TransferMode.Binary;
     
                    TransferOperationResult transferResult;
                    transferResult = session.PutFiles(@"d:\toupload\*", "/home/user/", false, transferOptions);
     
                    // Throw on any error
                    transferResult.Check();
     
                    // Print results
                    foreach (TransferEventArgs transfer in transferResult.Transfers)
                    {
                        Console.WriteLine("Upload of {0} succeeded", transfer.FileName);
                    }
                }
     
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e);
                return 1;
            }
        }
    }
