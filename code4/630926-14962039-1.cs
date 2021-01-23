    string LdapPath = ("LDAP://" + ldapUrl + "/" + Domain);
    //Build the user and issue the Refresh bind
    var dirEntry = new DirectoryEntry
                       {
                           Path = LdapPath,
                           Username = _usernameToVerify,
                           Password = _passwordToVerify,
                           AuthenticationType = AuthenticationTypes.ServerBind
                       };
    //This will load any available properties for the user
    dirEntry.RefreshCache();
