    internal static string MembershipTableName
    {
    	get { return "webpages_Membership"; }
    }
    private string SafeUserTableName
    {
    	get { return "[" + UserTableName + "]"; }
    }
    // represents the User table for the app
    public string UserTableName { get; set; }
