    static void Main( string[] args )
    {
    
        IEnumerable<User> users = GetADUsers();
    
        Console.WriteLine( "Users: " + users.Count().ToString() );
    
    }
    
    static DirectoryEntry ROOT = new DirectoryEntry( "LDAP://MyADDomainLocation.com" );
    
    private static IEnumerable<User> GetADUsers()
    {
        IEnumerable<User> users;
    
        var usersDS = new DirectorySource<User>( ROOT, SearchScope.Subtree );
    
                users = from usr in usersDS
                        where usr.Name == "A*" // FIlter A then any character(s)
                        select usr;
    
         users = users.OrderBy( user => user.Name ).ToList(); // Sort them alphabetically by name.
    
        return users;
    }
