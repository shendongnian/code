    using (DirectoryEntry entry = new DirectoryEntry())
    {
      entry.Path = "LDAP://xxx.xxx.xxx.xxx/DC=domainName,DC=com";
      entry.Username = @"domainName.com\Administrator";
      entry.Password = "SecurePassword";
      using (DirectorySearcher search = new DirectorySearcher(entry))
      {
        search.Filter = "(objectCategory=printQueue)";
        SearchResult result = search.FindOne();
        if (result != null)
        {
          ResultPropertyCollection fields = result.Properties;
          foreach (String ldapField in fields.PropertyNames)
          {
            foreach (Object myCollection in fields[ldapField])
              Console.WriteLine(String.Format("{0,-20} : {1}",
                              ldapField, myCollection.ToString()));
          }
        }
      }
    }
