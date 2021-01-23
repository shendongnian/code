    PasswordConnectionInfo connectionInfo = new PasswordConnectionInfo(hostAdres, hostNaam, wachtwoord); 
    connectionInfo.Timeout = TimeSpan.FromSeconds(30); 
    client = new SshClient( connectionInfo); 
    client.Connect(); 
    ForwardedPortLocal portFwld = new ForwardedPortLocal ("127.0.0.1", Convert.ToUInt32(hostpoort), DataBaseServer, Convert.ToUInt32(remotepoort)); client.AddForwardedPort(portFwld); 
    portFwld.Start(); 
    // using Renci.sshNet 
    connection = new MySqlConnection("server = " + "127.0.0.1" + "; Database = database; password = PWD; UID = yourname; Port = 22"); 
    connection.Open();
