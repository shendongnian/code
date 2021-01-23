        ...
        string ldapConn = GetLDAPConnection(domain, username, a_Password);                             
        DirectoryEntry entry = new DirectoryEntry(ldapConn, username, a_Password);        
        try
        {
            try
            {
                object obj = entry.NativeObject;
            }
            catch(DirectoryServicesCOMException comExc)
            {
                LogException(comExc);
                return false;
            }
            DirectorySearcher search = new DirectorySearcher(entry);
            search.Filter = string.Format("(SAMAccountName={0})", username);
            search.PropertiesToLoad.Add("cn");
            SearchResult result = search.FindOne();
