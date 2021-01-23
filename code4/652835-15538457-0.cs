    public string ChangePassword(string NewPassword)
    {
        MembershipUser u = Membership.GetUser();
        
        if (u.ChangePassword(u.ResetPassword(), NewPassword))
        {
              return "Password changed.";
        }
    }
