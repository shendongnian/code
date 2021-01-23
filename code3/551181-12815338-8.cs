    public class FindUsersBySearchTextQueryHandler
        : IQueryHandler<FindUsersBySearchTextQuery, User[]>
    {
        private readonly IUnitOfWork db;
 
        public FindUsersBySearchTextQueryHandler(IUnitOfWork db)
        {
            this.db = db;
        }
 
        public User[] Handle(FindUsersBySearchTextQuery query)
        {
            // example
            return (
                from user in this.db.Users
                where user.Name.Contains(query.SearchText)
                where user.IsActive || query.IncludeInactiveUsers
                select user)
                .ToArray();
        }
    }
