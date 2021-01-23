    string schemaURI = "http://schemas.microsoft.com/powershell/Microsoft.Exchange";
    Uri connectTo = new Uri("https://ps.outlook.com/powershell/");
    PSCredential credential = new PSCredential(user,secureStringPassword ); // the password must be of type SecureString
    WSManConnectionInfo connectionInfo = new WSManConnectionInfo(connectTo,schemaURI, credential);
    connectionInfo.MaximumConnectionRedirectionCount = 5;
    connectionInfo.AuthenticationMechanism = AuthenticationMechanism.Basic;
    
    try
    {
        Runspace remoteRunspace = RunspaceFactory.CreateRunspace(connectionInfo);
        remoteRunspace.Open();
    }
    catch(Exception e)
    {
        //Handle error 
    }
