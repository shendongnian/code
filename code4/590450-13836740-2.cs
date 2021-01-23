    using System.Linq; 
    public class UserRepository : IUserRepository
    {
        public IEnumerable<User> GetUsersByCompanyName(string companyName)
        // use Linq here
    }
