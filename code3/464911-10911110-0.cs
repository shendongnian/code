    var serverName = "...;
    var client = new TcpClient(serverName, 443);            
    // Create an SSL stream that will close the client's stream.
    using (var sslStream = new SslStream(client.GetStream(),true))
    {
        sslStream.AuthenticateAsClient(serverName);                
        var serverCertificate = sslStream.RemoteCertificate;
     }
