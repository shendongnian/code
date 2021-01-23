    public class FindUsersBySearchTextQueryHandler
        : IQueryHandler<FindUsersBySearchTextQuery, User[]>
    {
        private readonly NorthwindUnitOfWork db;
     
        public FindUsersBySearchTextQueryHandler(NorthwindUnitOfWork db)
        {
            this.db = db;
        }
     
        public User[] Handle(FindUsersBySearchTextQuery query)
        {
            return db.Users.Where(x => x.Name.Contains(query.SearchText)).ToArray();
        }
    }
