    /// Pipes/Filters for user queries.
    public static class UserExtensions
    {
        public static IQueryable<User> Active(this IQueryable<User> query)
        {
            return query.Where(user => user.Active == true);
        }
    }
    
    public class UserRepository : IRepository<User>, IUserRepository
    {
        /// Retrieve all users
        public List<User> List()
        {
            // Logic to query all users in the database.
        }
        public List<User> ListActive()
        {
            // Logic to query all active users in the database.
            return context.Users.Active().ToList();
        }
    }
