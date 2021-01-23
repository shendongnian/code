    public class UserController : Controller
    {
        private IQueryProcessor queryProcessor;
     
        public UserController(IQueryProcessor queryProcessor)
        {
            this.queryProcessor = queryProcessor;
        }
     
        public View SearchUsers(string searchString)
        {
            var query = new FindUsersBySearchTextQuery
            {
                SearchText = searchString,
                IncludeInactiveUsers = false
            };
     
            // Note how we omit the generic type argument,
            // but still have type safety.
            User[] users = this.queryProcessor.Process(query);
    
            return this.View(users);
        }
    }
