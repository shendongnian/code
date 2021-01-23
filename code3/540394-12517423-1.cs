    LdapConnection ldapConn = new LdapConnection();
    try
    {
       ldapConn.Connect(details of connection);
       ldapConn.Bind(details of bind statement);
    }
    catch (somesortofexception ex)
    {
       //Log, send error message..
       ldapConn = null;
    }
    if (ldapConn != null)
    {
        try
        {
             //Do what you need with your connection
        }
        catch (Exception ex)
        {
             //Log, Error....
        }
        finally
        {
            //Disconnect your ldap here
        }
    }
     
