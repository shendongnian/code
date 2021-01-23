using (PrincipalContext context = new PrincipalContext(ContextType.Domain, 
        "XXXX","ADMINUSER", "ADMINPASSWORD"))
{
    using (UserPrincipal user = 
        UserPrincipal.FindByIdentity(context,IdentityType.SamAccountName, username)) 
    {
        string tempPassword = Guid.NewGuid().ToString();
        user.SetPassword(tempPassword);
        user.ChangePassword(tempPassword, password);
    }
}
We reset the person's password to a random sufficiently long and complex password that our code knows. We then use that password as the old password in the change process using the new password that the user typed in. If the process fails the policy check including the password history, we pass that error back to the end user and they have to try again.
