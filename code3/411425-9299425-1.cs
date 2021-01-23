    public class UserService : IUserService
    {
        // If you need DI for this service, follow the same pattern of using 
        // fields and controller injection. I left examples in comment below.
        // private readonly IRepository _repository;
        // Constructor is unnecessary if you do not need DI example.
        public UserService(/* IRepository repository */) 
        {
            // _repository = repository;
        }
     
        // Methods
        public IEnumerable<User> Users()
        {
            return ((App)App.Current).Users;
        }
        public void AddUser(User user)
        {
            ((App)App.Current).Users.Add(user);
        }
    }
