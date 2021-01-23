    interface IUserRepository : IRepository<User, int>
    {
        User GetByUserName(string userName);
        IEnumerable FindByLastName(string lastName);
    }
