    using System.DirectoryServices;
    DirectoryEntry deTargetUser = new DirectoryEntry("LDAP://CN=joe.user,DC=blah,DC=com");
    DirectorySearcher dsSchema = new DirectorySearcher(deTargetUser.SchemaEntry);
    dsSchema.SearchScope = SearchScope.Base; //allowedAttributes is a constructed attribute, so have to ask for it while performing a search
    dsSchema.Filter = "(objectClass=*)"; //this is closest thing I can find to an always true filter
    dsSchema.PropertiesToLoad.Add("allowedAttributes");
    SearchResult srSchema = dsSchema.FindOne();
    var attributes = new List<string>();
    foreach(string attributeName in srSchema.Properties["allowedAttributes"])
    {
        attributes.Add(attributeName);
    }
