    public List<User> GetAllUsersWithoutAdmin()
    {
        return context.Users.AsNoTracking().Where(x => x.Id != 1)
            .OrderBy(x => x.FullName).ToList();
    }
    public User GetUser(int userId)
    {
        return context.Users.AsNoTracking().FirstOrDefault(x => x.Id == userId);
    }
    public string UpdateUserDetails(User user)
    {
        string info;
        try
        {
            User uUser = context.Users.FirstOrDefault(x => x.Id == user.Id);
            uUser.Category = user.Category;
            uUser.Email = user.Email;
            uUser.FullName = user.FullName;
            uUser.Login = user.Login;
            context.SaveChanges();
            Context.Entry(uUser).State = System.Data.EntityState.Detached;
            info = "success";
        }
        catch (Exception err)
        {
            info = err.Message;
        }
        return info;
    }
