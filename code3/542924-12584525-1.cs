    using (var search = new DirectorySearcher(myLdapConnection ))
    {
        search.Filter = "(objectClass=user)";          
        search.PropertiesToLoad.Add ( "department" );          
        search.PageSize = 1000; // any non-zero value will work
        using (var result = search.FindAll ( ))
        {
            ...
            foreach ( SearchResult depart in result )             
            {                 
                using (var directoryEntry = depart.GetDirectoryEntry ( ))
                {
                    ...
                }
            }
        }
    }
