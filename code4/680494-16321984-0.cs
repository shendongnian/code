    public static List<User> Select(int userId, bool? isActive = null)
    {
        var dl = DataLayer.GetDataContext();
        return dl.Users.Where(x => E(userId, isActive, x)).ToList();
    }
    static bool E(int userId, bool? isActive, User x)
    {
        return x.ID == userId && D(isActive, x);
    }
    static bool D(bool? isActive, User x)
    {
        return (!isActive.HasValue || C(isActive, x));
    }
    static bool C(bool? isActive, User x)
    {
        return (isActive.HasValue && B(isActive, x));
    }
    static bool B(bool? isActive, User x)
    {
        return x.IsActive == isActive.Value;
    }
