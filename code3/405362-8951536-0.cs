    private const int ERROR_LOGON_FAILURE = 0x31;
        
    private bool ValidateCredentials(string username, string password, string domain)
    {
        NetworkCredential credentials
            = new NetworkCredential(username, password, domain);
        LdapDirectoryIdentifier identifier = new LdapDirectoryIdentifier(domain);
        LdapConnection connection = new LdapConnection(identifier,
                                                       credentials,
                                                       AuthType.Kerberos);
        connection.SessionOptions.Sealing = true;
        connection.SessionOptions.Signing = true;
        try
        {
            connection.Bind();
        }
        catch (LdapException lEx)
        {
            if (ERROR_LOGON_FAILURE == lEx.ErrorCode)
            {
                return false;
            }
            throw;
        }
        return true;
    }
