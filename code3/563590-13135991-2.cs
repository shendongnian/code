    public class FindUsersBySearchTextQueryHandler
        : IQueryHandler<FindUsersBySearchTextQuery, User[]>
    {
        private readonly NorthwindUnitOfWork db;
 
        public FindUsersBySearchTextQueryHandler(
            NorthwindUnitOfWork db)
        {
            this.db = db;
        }
 
        public User[] Handle(FindUsersBySearchTextQuery query)
        {    
            return (
                from user in this.db.Users
                where user.Name.Contains(query.SearchText)
                select user)
                .ToArray();
        }
    }
