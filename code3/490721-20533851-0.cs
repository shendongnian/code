    private static IList<string> GetUserLocalGroups(string userAccountName, string computerName, string domainName)
    {
      List<string> groups = new List<string>();
      // We have to deal with a local computer
      DirectoryEntry root = new DirectoryEntry(String.Format("WinNT://{0},Computer", computerName), null, null, AuthenticationTypes.Secure);
      foreach (DirectoryEntry groupDirectoryEntry in root.Children)
      {
        if (groupDirectoryEntry.SchemaClassName != "Group")
          continue;
        string groupName = groupDirectoryEntry.Name;
        Console.WriteLine("Checking: {0}", groupName);
        if (IsUserMemberOfGroup(groupDirectoryEntry, String.Format("WinNT://{0}/{1}", domainName, userAccountName)))
        {
          groups.Add(groupName);
        }
      }
      return groups;
    }
    
    private static bool IsUserMemberOfGroup(DirectoryEntry group, string userPath)
    {
      return (bool)group.Invoke(
          "IsMember",
          new object[] { userPath }
          );
    }
