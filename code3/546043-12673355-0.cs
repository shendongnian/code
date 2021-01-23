    public static Boolean ResetPassword(string username, string password, string DomainId, string setpassword, Boolean UnlockAccount,Boolean NextLogon)
    {
       PrincipalContext pr = new PrincipalContext(ContextType.Domain, "corp.local", "dc=corp,dc=local", username, password);
       UserPrincipal user = UserPrincipal.FindByIdentity(pr, DomainId);
       
       Boolean flag = false;
       if (user != null && user.Enabled == true)
        {
           if (UnlockAccount)
            {
              user.UnlockAccount();
            }
            user.SetPassword(setpassword);
            if (NextLogon)
            {
              user.ExpirePasswordNow();
            }
            user.Save();
            flag = true;
        }
        else
          {
             flag = false;
          }
        user.Dispose();
        pr.Dispose();
        return flag;
       }
