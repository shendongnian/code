    using (UserPrincipal user = 
        UserPrincipal.FindByIdentity(context,IdentityType.SamAccountName, username)) 
    {
        string tempPassword = Guid.NewGuid().ToString();
        user.SetPassword(tempPassword);
        user.ChangePassword(tempPassword, password);
    }
