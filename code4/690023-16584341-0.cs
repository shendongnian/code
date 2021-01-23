    public interface IUserDao
    {
        Task<User> GetUser(int userId);
    }
    public async Task UserSelected(int userId)
    {
       User user = await daoFactory.UserDao.GetUser(userId);
       view.FirstName = user.FirstName;
       view.LastName = user.LastName;
    }
