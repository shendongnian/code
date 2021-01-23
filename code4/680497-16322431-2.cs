    public static List<User> Select(int userId)
    {
        return DataLayer.GetDataContext().Users.Where(x => x.ID == userId).ToList();
    }
    public static List<User> Select(int userId, bool isActive)
    {
        return DataLayer.GetDataContext().Users.Where(x => x.ID == userId && x.IsActive == isActive).ToList();
    }
