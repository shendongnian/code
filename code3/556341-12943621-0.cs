      var username = "your username";
      var password = "your password";
      var domain = "your domain";
      var ctx = new PrincipalContext(ContextType.Domain, domain, username, password);
      using (var searcher = new PrincipalSearcher(new UserPrincipal(ctx)))
      {
        foreach (var result in searcher.FindAll())
        {
          DirectoryEntry de = result.GetUnderlyingObject() as DirectoryEntry;
          Console.WriteLine("First Name: " + de.Properties["givenName"].Value);
          Console.WriteLine("Last Name : " + de.Properties["sn"].Value);
          Console.WriteLine("SAM account name   : " + de.Properties["samAccountName"].Value);
          Console.WriteLine("User principal name: " + de.Properties["userPrincipalName"].Value);
          Console.WriteLine();
        }
      }
