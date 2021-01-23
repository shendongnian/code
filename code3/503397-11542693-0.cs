    using (var user = new DirectoryEntry("LDAP://<IP/name>/CN=dummy,DC=corp", 
                                         "<admin>", 
                                         "<admin pass>"))
    {
      user.Invoke("SetPassword", new object[] { "password" });
      user.CommitChanges();
    }
