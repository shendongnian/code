    //Ex. (uid=jsmith)
    string filter = config.LdapAuth.LdapFilter.Replace("{{uid}}", username);
                
    //Find the user we're trying to authorize
    var lsc = lc.Search(config.LdapAuth.LdapDomain, LdapConnection.SCOPE_SUB, filter, null, false);
    if (lsc.hasMore())
    {
        LdapEntry nextEntry = lsc.next();
        //Check the Entries DN so we can properly bind 
        lc.Bind(nextEntry.DN, Password);
    }
