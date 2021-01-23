    public class UserRepository
    {
        Func<UserScope> _factory;
        [Inject]
        public UserRepository(Func<UserScope> factory)
        {
            _factory = factory;
        }
        public UserScope LoadUser()
        {
            return _factory(); // scopes preserved
        }
    }
    public class User
    {
        Func<Sheet> _sheetFactory; // multiple instances inside User scope
        public UserRepository Repository { get; } // same instance for app
        [Inject]
        public User(Func<Sheet> sheetFactory, UserRepository repository)
        {
            Repository = repository;
            _sheetFactory = sheetFactory;
        }
        public Sheet MakeSheet()
        {
            return _sheetFactory();
        }
    }
