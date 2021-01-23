     using X = Renci.SshNet;
         ConnectionInfo = new X.ConnectionInfo(_host, 22, _usr, 
            new X.AuthenticationMethod[] {
            new X.PasswordAuthenticationMethod (_usr, _pwd)
         }); //_host = yourfavoritesite.whatever.com -- take out sftp://
         SftpClient = new X.SftpClient(ConnectionInfo);
         SftpClient.Connect();
