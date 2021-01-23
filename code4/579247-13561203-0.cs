    bool b1 = IsInGroup("sAMAccountName", "LOCALGROUPNAME");
    
    
        static bool IsInGroup(string user, string group)
        {
          using (WindowsIdentity identity = new WindowsIdentity(user))
          {
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(group);
          }
        }
