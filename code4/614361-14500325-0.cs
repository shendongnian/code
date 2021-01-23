    public List<User> GetAllUsersWithoutAdmin()
    {
        return context.Users.Where(x => x.Id != 1).OrderBy(x => x.FullName)
           .AsNoTracking().ToList();
    }
    public User GetUser(int userId)
    {
        return context.Users.AsNoTracking().FirstOrDefault(x => x.Id == userId);
    }
