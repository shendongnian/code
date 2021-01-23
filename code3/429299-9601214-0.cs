    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(GolfEntities context)
            : base (context)
        {
        }
    
        public string FullName()
        {
            return "Full Name: Test FullName";
        }
    }
