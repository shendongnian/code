    public class UserModelBinder : IModelBinder
    {
        public Func<UserDataService> UserData { get; set; }
    
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Guid UserID = (Guid)Membership.GetUser().ProviderUserKey;
    
            User u = UserData().GetUser(UserID);
    
            return u;
        }
    }
