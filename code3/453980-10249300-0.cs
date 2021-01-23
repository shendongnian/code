    using (var context = new PrincipalContext(ContextType.Domain, "mydomain.com"))
    {
        using (var searcher = new PrincipalSearcher(new UserPrincipal(context) { GivenName = "fname", Surname = "lname" }))
        {
                foreach (var result in searcher.FindAll())
                {
                    DirectoryEntry de = result.GetUnderlyingObject() as DirectoryEntry;
                    return de.Properties["samAccountName"].Value.ToString();
                }
        }
    }
