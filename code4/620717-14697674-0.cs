    public static MembershipProvider CCMembershipProvider
    {
        get
        {
            return ((MembershipProvider)Membership.Providers["CC_MembershipProvider"]);
        }
    }
        
    public static MembershipUser getCCUser(Guid UserID)
    {
        return CCMembershipProvider.GetUser(UserID, false);
    }
        
    public static MembershipUser getCCUser(string userName)
    {
        //This function is BS.  For some reason userName always gets null.  Unfortunately UsersInRole only gives a string[]
        //Soo... Here is the jenky workaround...
        userName = userName.ToLower();
        
        CCPortal.MEMBERSHIPEntities context = new CC.MEMBERSHIPEntities();
        
        CCPortal.aspnet_Users user = context.aspnet_Users.SingleOrDefault(u => u.LoweredUserName == userName);
        
        return getCCUser(user.UserId);
        //This is what We should be using....
        //return CCMembershipProvider.GetUser(userName, false);
    }
