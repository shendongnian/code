    string hostNameAndSSLPort = "sea-dc-02.fabrikam.com:50001";
    string userName = "cn=User1,cn=AdamUsers,cn=ap1,dc=fabrikam,dc=com";
    string password = "adamPassword01!";
    
    // establish a connection
    LdapConnection connection = new LdapConnection(hostNameAndSSLPort);
    
    // create an LdapSessionOptions object to configure session 
    // settings on the connection.
    LdapSessionOptions options = connection.SessionOptions;
    
    options.ProtocolVersion = 3;
    
    options.SecureSocketLayer = true;
    
    connection.AuthType = AuthType.Basic;
    
    NetworkCredential credential =
            new NetworkCredential(userName, password);
    
    connection.Credential = credential;
    
    try
    {
        connection.Bind();
        Console.WriteLine("\nUser account {0} validated using " +
            "ssl.", userName);
    
        if (options.SecureSocketLayer == true)
        {
            Console.WriteLine("SSL for encryption is enabled\nSSL information:\n" +
            "\tcipher strength: {0}\n" +
            "\texchange strength: {1}\n" +
            "\tprotocol: {2}\n" +
            "\thash strength: {3}\n" +
            "\talgorithm: {4}\n",
            options.SslInformation.CipherStrength,
            options.SslInformation.ExchangeStrength,
            options.SslInformation.Protocol,
            options.SslInformation.HashStrength,
            options.SslInformation.AlgorithmIdentifier);
        }
    
    }
    catch (LdapException e)
    {
        Console.WriteLine("\nCredential validation for User " +
            "account {0} using ssl failed\n" +
            "LdapException: {1}", userName, e.Message);
    }
    catch (DirectoryOperationException e)
    {
        Console.WriteLine("\nCredential validation for User " +
        "account {0} using ssl failed\n" +
        "DirectoryOperationException: {1}", userName, e.Message);
    }
