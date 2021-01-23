    public class UserController : Controller
    {
        IQueryHandler<FindUsersBySearchTextQuery, User[]> handler;
 
        public UserController(
            IQueryHandler<FindUsersBySearchTextQuery, User[]> handler)
        {
            this. handler = handler;
        }
 
        public View SearchUsers(string searchString)
        {
            var query = new FindUsersBySearchTextQuery
            {
                SearchText = searchString,
                IncludeInactiveUsers = false
            };
 
            User[] users = this.handler.Handle(query);
            return this.View(users);
        }
    }
