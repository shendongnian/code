    public interface IAuthorizationService
    {
        void Register<T>(IAuthorizationModule module);
        bool Authorize<T>(T activity);
    }
    
    public class AuthorizationService : IAuthorizationService
    {
        private readonly Dictionary<Type, IAuthorizationModule> activities;
    
        public AuthorizationService()
        {
            activities = new Dictionary<Type, IAuthorizationModule>();
        }
    
        public void Register<T>(IAuthorizationModule module)
        {
            activities[typeof(T)] = module;
        }
    
        public bool Authorize<T>(T activity)
        {
            return activities[typeof(T)].Authorize(activity);
        }
    }
    public interface IAuthorizationModule
    {
        bool Authorize(OrderActivity activity);//no generic here
    }
    
    public class OrderAuthModule : IAuthorizationModule
    {
        public bool Authorize(OrderActivity activity)//no generic here either
        {
            return activity == OrderActivity.Cancel;
        }
    }
    
    public enum OrderActivity
    {
        Place,
        Cancel,
        Refund
    }
