    static void Main(string[] args)
    {
      /* Connection to Active Directory
       */
      DirectoryEntry deBase = new DirectoryEntry("LDAP://192.168.225.100:389/OU=SousMonou,OU=MonOu,DC=dom,DC=fr", "jpb", "pwd");
    
      /* User creation
      */
      DirectoryEntry auser = deBase.Children.Add("cn=a User", "user");
      auser.CommitChanges();
    
      auser.Properties["samaccountname"].Value = "AUser";
      auser.Properties["givenName"].Value = "A";
      auser.Properties["sn"].Value = "User";
      auser.Properties["displayName"].Value = "AUser";
      auser.Properties["userPrincipalName"].Value = "AUser@dom.fr";
      auser.Properties["pwdLastSet"].Value = 0;
      auser.Properties["userAccountControl"].Value = 544;
    
      auser.CommitChanges();
    
      /* Retreiving the user
      */
      DirectorySearcher dsLookForDomain = new DirectorySearcher(deBase);
      dsLookForDomain.Filter = "(&(cn=a User))";
      dsLookForDomain.SearchScope = SearchScope.Subtree;
    
      SearchResult srUser = dsLookForDomain.FindOne();
      if (srUser != null)
      {
        DirectoryEntry deUser = srUser.GetDirectoryEntry();
        deUser.Properties["departmentNumber"].Value = "Test Department";
        deUser.CommitChanges();
      }
    }
