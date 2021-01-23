    public class UserRepository : IUserRepository
    {
        public IEnumerable<User> GetUsersByCompanyName(string companyName)
        // do not use Linq here
    }
