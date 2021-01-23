    public enum UserRole
    {
        Admin = 1,
        Leader = 2,
        Editor = 3,
        Guest = 4
    }
    IList<UserRole> roles = new List<UserRole> { UserRole.Leader, UserRole.Editor };
    var min = roles.Min();
    var max = roles.Max();
    var result1 = Enum.GetValues(typeof(UserRole)).Cast<UserRole>()
                                                  .Where(x => x <= min);
    var result = Enum.GetValues(typeof(UserRole)).Cast<UserRole>()
                                                 .Where(x => x >= max);
