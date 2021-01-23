    System.Security.Principal.IIdentity id = System.Web.HttpContext.Current.User.Identity
    if (id.Name != System.Security.Principal.WindowsIdentity.GetCurrent().Name)
    {
        context = (id as System.Security.Principal.WindowsIdentity).Impersonate()
    }
