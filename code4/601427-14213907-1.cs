    public static void AddContactToGroup(string ContactDN, string GroupDN)
    {
      try
      {
        using (DirectoryEntry directoryEntry = new DirectoryEntry("LDAP://" + GroupDN))
        {
          directoryEntry.RefreshCache();
          DirectoryEntry Contactgroup = new DirectoryEntry("LDAP://" + ContactDN);
          directoryEntry.Properties["member"].Add(Contactgroup.Properties["distinguishedName"].Value);
          directoryEntry.CommitChanges();
        }
      }
      catch (Exception e)
      {
        string msg = e.Message.ToString();
        throw e;
      }
    }
