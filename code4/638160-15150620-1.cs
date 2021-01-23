    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IMyContext context)
            : base(context)
        {
        }
        public void AddList(String name)
        {
        }
    }
