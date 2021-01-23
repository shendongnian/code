    public MembershipStatus Authenticate(string username, string password)
    {
        using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Snapshot }))
        {
        MembershipUser user = Membership.GetUser(username);
            if (user == null)
            {
                // user did not exist as of Membership.GetUser
                return MembershipStatus.InvalidUsername;
            }
            if (user.IsLockedOut)
            {
                // user was locked out as of Membership.GetUser
                return MembershipStatus.AccountLockedOut;
            }
            if (Membership.ValidateUser(username, password))
            {
                // user was valid as of Membership.ValidateUser
                return MembershipStatus.Valid;
            }
            // user was not valid as of Membership.ValidateUser BUT we don't really
            // know why because we don't have ISOLATION.  The user's status may have changed
            // between the call to Membership.GetUser and Membership.ValidateUser.
            return MembershipStatus.InvalidPassword;
        }
    }
