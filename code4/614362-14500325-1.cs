    public List<User> GetAllUsersWithoutAdmin()
    {
        return context.Users.AsNoTracking().Where(x => x.Id != 1)
            .OrderBy(x => x.FullName).ToList();
    }
    public User GetUser(int userId)
    {
        return context.Users.AsNoTracking().FirstOrDefault(x => x.Id == userId);
    }
