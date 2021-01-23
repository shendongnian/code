    public class UserRepository : IRepository<User>, IUserRepository
    {
        // other queries.
        public List<User> List(ISearchQuery query)
        {
            // Logic to query all active users in the database.
            return context.Users.Active().LivesIn(query.Country).WithAccounts(query.AccountsAtLeast).ToList();
        }
    }
    public static class UserExtensions
    {
        // other pipes and filters.
        public static IQueryable<User> LivesIn(this IQueryable<User> query, string country)
        {
            return query.Where(user => user.Country.Name == country);
        }
        public static IQueryable<User> WithAccounts(this IQueryable<User> query, int count)
        {
            return query.Where(user => user.Accounts.Count() >= count);
        }
    }
