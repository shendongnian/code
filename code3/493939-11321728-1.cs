    DirectoryEntry entry = new DirectoryEntry(string.Format("LDAP://{0}", sUserDomain));
    DirectorySearcher mySearcher = new DirectorySearcher(entry);
    mySearcher.Filter = string.Format("(&(objectClass=user) (cn= {0}))", ui.DisplayName.ToString());
    mySearcher.PropertiesToLoad.Add("memberOf");
    SearchResult searchresult = mySearcher.FindOne();
    foreach (string dn in searchresult.Properties["memberOf"])
    {
        DirectoryEntry group = new DirectoryEntry(string.Format("LDAP://{0}/{1}", sUserDomain, dn));
        SecurityIdentifier sid = new SecurityIdentifier(group.Properties["objectSid"][0] as byte[], 0);
        Console.Out.WriteLine(sid.Value);
    }
