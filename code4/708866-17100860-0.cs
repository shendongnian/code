    public class OrderAuthModule : IAuthorizationModule
    {
        public bool Authorize<T>(T activity)
        {
            return activity.ToString() == OrderActivity.Cancel.ToString();
        }
    }
