    // Since you know the domain and user
    PrincipalContext context = new PrincipalContext(ContextType.Domain);
    // Create the principal user object from the context
    UserPrincipal usr = new UserPrincipal(context);
    usr .GivenName = "Jim";
    usr .Surname = "Daly";
    // Create a PrincipalSearcher object.
    PrincipalSearcher ps = new PrincipalSearcher(usr);
    PrincipalSearchResult<Principal> results = ps.FindAll();
    foreach (UserPrincipal user in results) {
        if(user.DisplayName == userName) {
            var usersSid = user.Sid.ToString();
        }
    }
