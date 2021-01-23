    public class AppUserRepository : IAppUserRepository
    {
        private readonly IDbConnectionFactory dbConnectionFactory;
        public class AppUserRepository(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }
    
        public AppUser GetAppUserByUsername(string username)
        {
            AppUser appUser;
            using (var db = this.dbConnectionFactory.OpenDbConnection())
            {
                appUser = db.QuerySingle<AppUser>(new { username });
            }
            return appUser;
        }
    }
