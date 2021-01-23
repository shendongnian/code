    string hostOrDomainName = "fabrikam.com";
    string userName = "user1";
    string password = "password1";
    
    // establish a connection to the directory
    LdapConnection connection = new LdapConnection(hostOrDomainName);
    
    NetworkCredential credential =
        new NetworkCredential(userName, password, domainName);
    
    connection.Credential = credential;
    
    connection.AuthType = AuthType.Basic;
    
    LdapSessionOptions options = connection.SessionOptions;
    
    options.ProtocolVersion = 3;
    
    try
    {
        options.StartTransportLayerSecurity(null);
        Console.WriteLine("TLS started.\n");
    }
    catch (Exception e)
    {
        Console.WriteLine("Start TLS failed with {0}", 
            e.Message);
        return;
    }
    
    try
    {
        connection.Bind();
        Console.WriteLine("Bind succeeded using basic " +
            "authentication and SSL.\n");
    
        Console.WriteLine("Complete another task over " +
            "this SSL connection");
        TestTask(hostName);
    }
    catch (LdapException e)
    {
        Console.WriteLine(e.Message);
    }
    
    try
    {
        options.StopTransportLayerSecurity();
        Console.WriteLine("Stop TLS succeeded\n");
    }
    catch (Exception e)
    {
        Console.WriteLine("Stop TLS failed with {0}", e.Message);
    }
    
     Console.WriteLine("Switching to negotiate auth type");
     connection.AuthType = AuthType.Negotiate;
    
     Console.WriteLine("\nRe-binding to the directory");
     connection.Bind();
    
    // complete some action over this non-SSL connection
    // note, because Negotiate was used, the bind request 
    // is secure. 
    // run a task using this new binding
    TestTask(hostName);
