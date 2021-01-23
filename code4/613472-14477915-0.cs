    public static bool IsInRoleAuthorAdminOrSuper(this IPrincipal user)
    {
       return user.IsInRole("Admin") 
           || user.IsInRole("Author") 
           || user.IsInRole("Super");
    }
