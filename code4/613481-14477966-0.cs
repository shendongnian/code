    public static bool IsInAnyRole(this IPrincipal principal, params string[] roles)
    {
        foreach(var role in roles)
        {
            if(principal.IsInRole(role))
            {
                return true;
            }
        }
    
        return false;
    }
