    public static List<User> Select(int userId, bool? isActive = null)
    {
        var dl = DataLayer.GetDataContext();
        return isActive.HasValue ? 
            dl.Users.Where(x => x.ID == userId && x.IsActive == isActive.Value).ToList() :
            dl.Users.Where(x => x.ID == userId).ToList();
    }
