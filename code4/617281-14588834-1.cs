    public class MembershipRepository : IMembershipRepository
    {
        private readonly WebStoreDataContext _dataContext;
        public MembershipRepository(WebStoreDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IEnumerable<User> GetUsers()
        {
            return _dataContext.Users;
        }
        public Guid GetUserId(string name)
        {
            return _dataContext.Users.Where(u => u.UserName == name).Select(u => u.UserId).Single();
        }
    }
