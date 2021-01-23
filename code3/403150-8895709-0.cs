    /// <summary>
    /// Gets the LDAP users from the LDAP server.
    /// </summary>
    /// <param name="ldapServer">The LDAP server, string format: "LDAP://172.22.100.10:389/OU=AT,O=ON"</param>
    /// <param name="directoryType">Type of the directory.</param>
    /// <param name="user">The user.</param>
    /// <param name="password">The password.</param>
    /// <param name="domain">The domain (AD only).</param>
    /// <returns>String list of LDAP users.</returns>
    public List<string> GetLdapUsers(string ldapServer, LocalDirectoryType directoryType, string user, string password, string domain)
    {
    	List<string> LdapUsers = new List<string>();
    
    	string serverName = Regex.Match(ldapServer, @"^.+//(.+?):").Groups[1].ToString();
    	string distinguishedName = ldapServer.Substring(ldapServer.LastIndexOf("/") + 1);
    
    	LdapConnection connection = new LdapConnection(new LdapDirectoryIdentifier(serverName));
    	switch (directoryType)
    	{
    		case LocalDirectoryType.ActiveDirectory:
    			connection.AuthType = AuthType.Ntlm;
    			break;
    		case LocalDirectoryType.eDirectory:
    			connection.AuthType = AuthType.Basic;
    			break;
    	}
    
    	// attempt to connect
    	try { connection.Bind(new NetworkCredential(user, password)); }
    	catch (Exception exception)
    	{
    		Trace.WriteLine(exception.ToString());
    	}
    
    	// run search for users
    	SearchResponse response = connection.SendRequest(new SearchRequest(distinguishedName, "(|(objectClass=person)(objectClass=user))", System.DirectoryServices.Protocols.SearchScope.Subtree, null)) as SearchResponse;
    
    	// extract users from results based on server type
    	if (directoryType == LocalDirectoryType.ActiveDirectory)
    	{
    		foreach (SearchResultEntry entry in response.Entries)
    		{
    			if (entry.Attributes.Contains("sAMAccountName") && entry.Attributes["sAMAccountName"][0].ToString() != String.Empty)
    				LdapUsers.Add(domain + "\\" + entry.Attributes["sAMAccountName"][0].ToString());
    		}
    	}
    	else
    	{
    		foreach (SearchResultEntry entry in response.Entries)
    		{
    			if (entry.Attributes.Contains("cn") && entry.Attributes["cn"][0].ToString() != String.Empty)
    			{
    				LdapUsers.Add("cn=" + entry.Attributes["cn"][0].ToString());
    			}
    
    		}
    	}
    
    	return LdapUsers;
    }
