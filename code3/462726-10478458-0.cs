    [Flags]
    public enum RoleType
    {
        Supervisor = 1,
        Administrator = 2,
        User = 4,
        UserPhone = 8,
        Operator = 16
    }
    // assume there is a user class with a collection of roles which have role types
    var roles = (RoleType)user.Roles.Sum( o => o.RoleType );
    if( roles.HasFlag( RoleType.User ) ){
        // do something
    }
