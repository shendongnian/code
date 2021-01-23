    public class UserRepository : IUserRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public UserRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }
        public IEnumerable<User> List()
        {
            using (var dbConnection = _dbConnectionFactory.CreateConnection())
            {
				....
            }
        }
    }
