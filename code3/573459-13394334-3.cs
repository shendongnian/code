    interface IUserRepository<User, int>
    {
        User GetByUserName(string userName);
        IEnumerable FindByLastName(string lastName);
    }
