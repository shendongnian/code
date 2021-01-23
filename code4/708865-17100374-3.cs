    public class AuthorizationService : IAuthorizationService
    {
        private readonly Dictionary<Type, object> activities;
    
        public AuthorizationService()
        {
            activities = new Dictionary<Type, object>();
        }
    
        public void Register<T>(IAuthorizationModule<T> module)
        {
            activities[typeof(T)] = module;
        }
    
        public bool Authorize<T>(T activity)
        {
            return ((IAuthorizationModule<T>)activities[typeof(T)]).Authorize(activity);
        }
    }
