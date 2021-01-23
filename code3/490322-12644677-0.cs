    using (var group = new DirectoryEntry("LDAP://CN=MyGroup,OU=MyOU,DC=company,DC=com"))
    {
       string baseDN = (string)group.Properties["msExchDynamicDLBaseDN"].Value;
       string filter = (string)group.Properties["msExchDynamicDLFilter"].Value;
       
       using (var searchRoot = new DirectoryEntry("LDAP://" + baseDN))
       using (var searcher = new DirectorySearcher(searchRoot, filter, propertiesToLoad))
       using (var results = searcher.FindAll())
       {
          foreach (SearchResult result in results)
          {
             // Use the result
          }
       }
    }
