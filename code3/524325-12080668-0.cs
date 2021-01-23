    public IEnumerable<User> GetAllUsers()
    {
        IRepository<User> userRepository = new Repository<User>(dbContext);
        UserBLL userBLL = new UserBLL(userRepository);
        return userBLL.GetAllUsers();
    }
