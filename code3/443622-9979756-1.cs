    // Since you know the domain and user
    PrincipalContext context = new PrincipalContext(ContextType.Domain);
    // Create the principal user object from the context
    UserPrincipal usr = new UserPrincipal(ctx);
    usr .GivenName = "Jim";
    usr .Surname = "Daly";
    // Create a PrincipalSearcher object.
    PrincipalSearcher ps = new PrincipalSearcher(usr);
    PrincipalSearchResult<Principal> fr = ps.FindAll();
    foreach (UserPrincipal user in results) {
        if(user.DisplayName == userName) {
            var usersSid = user.Sid;
        }
    }
