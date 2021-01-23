    public interface IAuthorizationModule<T>
    {
        bool Authorize(T activity);
    }
    
    public class OrderAuthModule : IAuthorizationModule<OrderActivity>
    {
        public bool Authorize<OrderActivity>(OrderActivity activity)
        {
            return activity == OrderActivity.Cancel;
        }
    }
