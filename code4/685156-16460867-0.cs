    public class ItemAuthorizeAttribute : AuthorizeAttribute{
    
        protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext){
            var userRepository = Container.Get<IRepository<User>>();
            var userName = httpContext.User.Identity.Name.GetOnlyUserName();
            var user = userRepository.GetBy(u => u.Name == userName && u.IsEnabled).FirstOrDefault();
            if (user == null) return false;
            user.Identity = httpContext.User.Identity;
            httpContext.User = user;
            ItemId = httpContext.Request["id"].ToInt();
            var itemRepository = Container.Get<IItemRepository>();
            var item = itemRepository .Get(ItemId );
            var currentUser = Container.Get<CurrentUser>();
            currentUser.user = user;
            var isUserPermitted = base.AuthorizeCore(httpContext);
            if (isUserPermitted)
            {
                return true;
            }
            if (item!= null)
            {
                if (!item.IsBanned)
                {
                    return true;
                }
            }
            return false;
        } 
    }
     protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
           // Unauthorize request URL
        }
