    public class UserScope : IDisposable
    {
        [Inject]
        public UserScope(User user, IResolutionRoot resolver)
        {
            User = user;
            Resolver = resolver;
        }
        public User User { get; }
        public IResolutionRoot Resolver { get; } // you can use this to resolve anything from inside **this** user scope
    }
