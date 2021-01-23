    using System.DirectoryServices;
    
    DirectoryEntry objEntry = DirectoryEntry(Ldapserver, userid, password);
    DirectorySearcher personSearcher = new DirectorySearcher(objEntry);
    personSearcher.Filter = string.Format("(SAMAccountName={0}", username);
    SearchResult result = personSearcher.FindOne();
    
    if(result != null)
    {
        DirectoryEntry personEntry = result.GetDirectoryEntry();
        PropertyValueCollection groups = personEntry.Properties["memberOf"];
        foreach(string g in groups)
        {
            Console.WriteLine(g); // will write group name
        }
    }
